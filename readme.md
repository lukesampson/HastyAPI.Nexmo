Overview
========

A .NET library for accessing the [Nexmo](http://www.nexmo.com) API.

To use it
=========

var response = new Nexmo(key, secret).Send(from, to, text);


International numbers
---------------------

Nexmo requires numbers in international format. If you have numbers in local format, you can use the International.Convert(number, [region]) methods to help with this.

US and Canadian numbers shouldn't need conversion.

Note: I haven't tested this on anything other than Australia, NZ and UK numbers, so please let me know if it doesn't work for your country.