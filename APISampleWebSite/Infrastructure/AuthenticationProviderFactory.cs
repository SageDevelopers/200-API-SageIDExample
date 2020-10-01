using SageID.ConfidentialClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APISampleWebSite
{
	public static class AuthenticationProviderFactory
	{
		/// <summary>
		/// The base uri for this machine
		/// </summary>
		public const string BaseUri = @"http://localhost:56953/";

		/// <summary>
		/// The Uri on which the authorisation server will call back into this application
		/// </summary>
		public const string LogonCallbackUri = BaseUri + "Account/Authorise";

		private static AuthenticationProvider _provider;

		static AuthenticationProviderFactory()
		{
			_provider = new AuthenticationProvider();

			/// Need to set the ClientID and Scope used for SageID authentication. 
			/// These values must be set before you can logon using SageID so set them early.
			/// The secret key is your confidential client secret key.
			/// The values below can be used for development but once you have an 
			/// app ready for production you must get a specific client id and scope 
			/// for you application by contacting developer support.
			_provider.ClientID = "";
			_provider.Scope = "";
			_provider.SecretKey = "";

			_provider.LogonCallbackUri = LogonCallbackUri;
		}

		public static AuthenticationProvider GetProvider()
		{
			return _provider;
		}
	}
}