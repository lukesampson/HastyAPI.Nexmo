using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HastyAPI.Nexmo {
	public class SubmissionResponse {
		public int MessageCount { get; set; }
		public List<Message> Messages { get; set; }
	}
}
