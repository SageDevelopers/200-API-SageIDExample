using SageID.PublicClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISampleWinFormsApp
{
	public static class AuthenticationProviderFactory
	{
		private static AuthenticationProvider _provider;

		static AuthenticationProviderFactory()
		{
			_provider = new AuthenticationProvider();

			// Set the ClientID and Scope used for SageID authentication. The values below can be 
			// used for development but once you have an app ready for production you must get a 
			// specific client id and scope for you application by contacting developer support.
			// The IsSilent flag is used to control behaviour on first logon of the app.
			// If IsSilent is false: you will be prompted every time you start the app.
			// If IsSilent is true: you will be prompted only when Refresh token has expired.
			_provider.ClientID = "";
			_provider.Scope = "";
			_provider.IsSilent = false;
		}

		public static AuthenticationProvider GetProvider()
		{
			return _provider;
		}
	}
}
