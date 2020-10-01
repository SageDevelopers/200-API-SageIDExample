using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIClientLibrary;
using SageID.PublicClient;

namespace APISampleWinFormsApp
{
	/// <summary>
	/// APIClientFactory is used to create a new instance of the APIClient 
	/// and to ensure that all required properties are set to support API calls.
	/// </summary>
	public static class APIClientFactory
	{
		/// <summary>
		/// The Company the request is for.
		/// Every request requires a company identifier.
		/// This is set once by your application 
		/// and used for all subsequent calls
		/// </summary>
		public static string CompanyID { get; set; }

		/// <summary>
		/// The Site the request is for.
		/// Every request requires a site identifier.
		/// This is set once by your application 
		/// and used for all subsequent calls.
		/// </summary>
		public static string SiteID { get; set; }

		/// <summary>
		/// The CreateNew method creates an instance of the APIClient for use
		/// in your application.
		/// Here you must specify your SUBSCRIPTION KEY, SIGNING KEY and BASEURL
		/// The base url will be different if you are using a Murano API, however it
		/// follows the same pattern as Sage 200, so it is the url up to but not 
		/// including the version number.
		/// </summary>
		/// <returns>A configured APIClient</returns>
		public static APIClient CreateNew()
		{
			// Create a new instance of the APIClient.
			APIClient apiClient = new APIClient();
			// Set the base URL, this sample is for Sage 200.
			apiClient.BaseUrl = @"https://api.columbus.sage.com/uk/sage200/accounts/";
			// Enter your developer subscription key (from the developer portal).
			apiClient.SubscriptionKey = "Enter your subscription key here";
            // Enter your developer signing key (from the developer portal).
            apiClient.SigningKey = "Enter your signing key here";

            // Validate that values have been set
            if (string.IsNullOrEmpty(apiClient.SubscriptionKey) || apiClient.SubscriptionKey.ToLower().StartsWith("enter"))
			{
				throw new System.ArgumentException("Please edit APIClientFactory.cs and specify your SubscriptionKey");
			}
			if (string.IsNullOrEmpty(apiClient.SigningKey) || apiClient.SigningKey.ToLower().StartsWith("enter"))
			{
				throw new System.ArgumentException("Please edit APIClientFactory.cs and specify your SigningKey");
			}

            // The following line will get a SageID security token based on the 
            // ClientID and Scope defined in AuthenticationProviderFactory.cs.
            // If you are not signed in, then this will present a sign in screen, 
            // where you must sign in to receive a security token.
            // If you are already signed in, it will return a security token.
            // It’s important to make this call on every request: to ensure that you have a new and valid Access Token.
            // If the access token has expired: it will silently get you a new access token by making use of the Refresh token.
            // If the Refresh token has also expired, it will then prompt user for sign in. 
            apiClient.AccessToken = AuthenticationProviderFactory.GetProvider().GetToken();

			// Company is a required header on the majority of requests for the Sage 200 API so
			// that the request can be routed to the correct company, exceptions would include GetSites().
			apiClient.CompanyID = CompanyID;
			// SiteID is a required header on the majority of requests for the Sage 200 API so
			// that the request can be routed to the correct site, exceptions would include GetSites().
			apiClient.SiteID = SiteID;

			// Returns the configured client.
			return apiClient;
		}
	}
}
