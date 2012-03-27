using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HastyAPI.Nexmo.Tests {
	public class Shared {
		public static string Key;
		public static string Secret;
		public static string Mobile; // mobile number for testing

		public static void LoadAuth() {
			if(!string.IsNullOrEmpty(Key) && !string.IsNullOrEmpty(Secret)) return; // already loaded

			var path = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\")).FullName;
			var cachepath = Path.Combine(path, "auth.cache");

			if(!File.Exists(cachepath)) {
				File.WriteAllText(cachepath, "key:secret");
				throw new Exception("Please set auth info in " + cachepath);
			}
			var cached = File.ReadAllText(cachepath).Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
			if(cached.Length != 3) throw new Exception("auth.cache format is invalid, should be key:secret:mobile");

			Key = cached[0];
			Secret = cached[1];
			Mobile = cached[2];
		}

		public static Nexmo NewNexmo() {
			LoadAuth();
			return new Nexmo(Key, Secret);
		}
	}
}
