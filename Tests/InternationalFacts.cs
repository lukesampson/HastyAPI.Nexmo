using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Globalization;
using System.Threading;

namespace HastyAPI.Nexmo.Tests {
	public class InternationalFacts {

		[Fact]
		public void Will_Use_Culture_Info_From_Current_Thread() {
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-NZ");
			Assert.Equal("6421567434", International.Convert("(021) 567 434"));
		}
		
		[Fact]
		public void Australia_Converts() {
			Assert.Equal("61420999888", International.Convert("0420 999 888", "au"));
		}

		[Fact]
		public void Not_Australia_Doesnt_Convert() {
			Assert.Equal("032999888", International.Convert("032 999 888", "au"));
		}

		[Fact]
		public void NewZealand_Converts() {
			Assert.Equal("6421567434", International.Convert("(021) 567 434", "nz"));
		}

		[Fact]
		public void UnitedKingdom_Converts() {
			Assert.Equal("447525856424", International.Convert("07525 856 424", "GB"));
		}

		[Fact]
		public void China_Converts() {
			Assert.Equal("8613155557777", International.Convert("131 5555 7777", "cn"));
		}

		[Fact]
		public void Russia_Converts() {
			Assert.Equal("7904111222", International.Convert("904 111 222", "RU"));
		}
	}
}
