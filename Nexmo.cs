using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HastyAPI.Nexmo {
	public class Nexmo {

		const string URL = "https://rest.nexmo.com/sms/json";

		public string Key { get; set; }
		public string Secret { get; set; }

		public Nexmo(string key, string secret) {
			Key = key;
			Secret = secret;
		}

		public SubmissionResponse Send(string from, string to, string text) {
			var response = new APIRequest(URL).WithForm(new {
					username = Key,
					password = Secret,
					from = from,
					to = to,
					text = text
				})
				.Post().EnsureStatus(200);

			System.Diagnostics.Debug.Write("received response:\n" + response.Text);

			var json = response.AsJSON();
			var result = new SubmissionResponse { MessageCount = int.Parse(json.message_count), Messages = new List<Message>() };
			foreach(var m in json.messages) {
				var msg = new Message { Status = (ResponseCode)int.Parse(m.status), MessageID = m.message_id, To = m.to, ClientRef = m.client_ref, ErrorText = m.error_text };

				if(m.remaining_balance != null) {
					decimal balance;
					if(decimal.TryParse(m.remaining_balance, out balance)) msg.RemainingBalance = balance;
				}

				if(m.message_price != null) {
					decimal price;
					if(decimal.TryParse(m.message_price, out price)) msg.MessagePrice = price;
				}

				result.Messages.Add(msg);
			}

			return result;
		}
	}
}
