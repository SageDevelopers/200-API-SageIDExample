using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APISampleWebSite
{
	/// <summary>
	/// Stores application-specific context eg Site, Company for Sage 200
	/// </summary>
	public static class ContextStore
	{
		/// <summary>
		/// Constant to identify siteID key value for ContextStore SiteID
		/// </summary>
		private const string keySiteID = "ContextStore.SiteID";

		/// <summary>
		/// Constant to identify CompanyNumber key value for ContextStore CompanyNumber
		/// </summary>
		private const string keyCompanyNumber = "ContextStore.CompanyNumber";

		/// <summary>
		/// Move values from Sage 200 SessionContext to HttpContext (for next web request)
		/// </summary>
		/// <param name="session">The session</param>
		/// <param name="siteID">The site ID</param>
		/// <param name="companyID">The company ID</param>
		public static void Set(HttpSessionStateBase session, string siteID, string companyID)
		{
			session[keySiteID] = siteID;
			session[keyCompanyNumber] = companyID;
		}

		/// <summary>
		/// Gets the site ID from the HTTPContext as a string
		/// </summary>
		/// <param name="session">The HTTPContext</param>
		/// <returns>The site ID as a string</returns>
		public static string GetSiteID(HttpSessionStateBase session)
		{
			return session[keySiteID] as string;
		}

		/// <summary>
		/// Gets the company ID from the HTTPContext as a string
		/// </summary>
		/// <param name="session">The HTTPContext</param>
		/// <returns>The company ID as a string</returns>
		public static string GetCompanyID(HttpSessionStateBase session)
		{
			return session[keyCompanyNumber] as string;
		}

		/// <summary>
		/// Delete values from HttpContext (for next web request)
		/// </summary>
		/// <param name="session">The HTTPContext</param>
		public static void Reset(HttpSessionStateBase session)
		{
			session[keySiteID] = null;
			session[keyCompanyNumber] = null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="session">The HTTPContext</param>
		/// <returns>True if site ID and company ID are set, otherwise false</returns>
		public static bool IsValid(HttpSessionStateBase session)
		{
			bool value = false;

			string siteID = GetSiteID(session);
			string companyID = GetCompanyID(session);

			value = (string.IsNullOrEmpty(siteID) == false) && (string.IsNullOrEmpty(companyID) == false);

			return value;

		}
	}
}