using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HastyAPI.Nexmo {
	public class Message {
		public ResponseCode Status { get; set; }
		public string MessageID { get; set; }
		public string To { get; set; }
		public string ClientRef { get; set; }
		public decimal RemainingBalance { get; set; }
		public decimal MessagePrice { get; set; }
		public string ErrorText { get; set; }
	}
}
