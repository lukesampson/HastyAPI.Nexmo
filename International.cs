using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace HastyAPI.Nexmo {
	public static class International {

		// region code: local prefix, international prefix
		static Dictionary<string, Tuple<string,string>> conversions = new Dictionary<string, Tuple<string, string>>(StringComparer.OrdinalIgnoreCase){

			{ "AU", Tuple.Create("04", "614") },      // Australia
			{ "CN", Tuple.Create("1[3-9]", "86$0") }, // China
			{ "GB", Tuple.Create("07", "447") },      // United Kingdom
			{ "NZ", Tuple.Create("02", "642") },      // New Zealand
			{ "RU", Tuple.Create("9", "79") },        // Russia
			{ "ZA", Tuple.Create("07", "277") }       // South Africa
		};

		// no conversion needed for these regions
		static HashSet<string> no_conversion = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "us", "ca" };

		/// <summary>
		/// Find out if this class knows how to convert numbers for the specified region.
		/// </summary>
		public static bool Supported(string region) {
			if(region == null) throw new ArgumentNullException("region");
			if(region.Length != 2) throw new ArgumentException("region \"" + region + "\" isn't a 2-letter region code");

			return no_conversion.Contains(region) || conversions.ContainsKey(region);
		}

		/// <summary>
		/// Converts a mobile number in a local format to international format.
		/// </summary>
		/// <param name="number">A mobile/cell number in local format</param>
		/// <param name="region">A 2-letter ISO 3166 region code</param>
		public static string Convert(string number, string region) {
			if(number == null) throw new ArgumentNullException("number");
			if(region == null) throw new ArgumentNullException("region");

			if(region.Length != 2) throw new ArgumentException("region \"" + region + "\" isn't a 2-letter region code");

			number = Regex.Replace(number, @"[^0-9]", "");

			if(no_conversion.Contains(region)) return number; // no conversion necessary

			Tuple<string, string> mapping;
			if(!conversions.TryGetValue(region, out mapping)) return number; // don't know how to convert it

			var localPrefix = mapping.Item1;
			var inlPrefix = mapping.Item2;

			number = Regex.Replace(number, @"^" + localPrefix, inlPrefix);

			return number;
		}

		/// <summary>
		/// Converts a mobile number in local format to international format, based on the region info for the current thread.
		/// </summary>
		/// <param name="number">A mobile/cell number in local format for the current region</param>
		public static string Convert(string number) {
			return Convert(number, RegionInfo.CurrentRegion.Name);
		}
	}
}
