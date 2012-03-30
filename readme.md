Nexmo API for .NET
==================

A .NET library for accessing the [Nexmo](http://www.nexmo.com) API. The docs for the Nexmo API are [here](http://nexmo.com/documentation/).

To use it
=========

First you need to [sign up](http://dashboard.nexmo.com/register) and get your API key and secret.

Then:

    var response = new Nexmo(key, secret).Send(from, to, text);


International numbers
---------------------

Nexmo requires numbers in international format. If you have numbers in local format, you can use the `International.Convert(number, [region])` methods to help with this.

US and Canadian numbers shouldn't need conversion.

Note: I haven't tested this on anything other than Australia, NZ and UK numbers, so please [report an issue](https://github.com/lukesampson/HastyAPI.Nexmo/issues) if it doesn't work for your region.