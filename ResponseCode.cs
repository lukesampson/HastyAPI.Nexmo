using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HastyAPI.Nexmo {
	public enum ResponseCode {
		Success = 0,
		Throttled = 1,
		MissingParams = 2,
		InvalidParams = 3,
		InvalidCredentials = 4,
		InternalError = 5,
		InvalidMessage = 6,
		NumberBarred = 7,
		PartnerAccountBarred = 8,
		PartnerQuotaExceeded = 9,
		TooManyExistingBinds = 10,
		AccountNotEnabledForRest = 11,
		MessageTooLong = 12,
		InvalidSenderAddress = 15,
		InvalidTTL = 16
	}
}
