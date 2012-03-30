using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HastyAPI.Nexmo.Tests {
	public class SendMessageFacts {

		// not a unit test!
		public void CanSend() {
			var response = Shared.NewNexmo().Send("HastyNexmo", Shared.Mobile, "Hello, nexmo! It's " + DateTime.Now.ToString("hh:mm tt") + ".");

			Console.Write("Message count: " + response.MessageCount);
		}
	}
}
