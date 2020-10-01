using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SageID.ConfidentialClient;

namespace APISampleWebSite
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);


			/// Specify implementation of AuthorisationAttemptRepository.
			/// Note: The sample implementation works only if your website is hosted on a 
			/// single server.
			/// If your website is hosted across multiple servers, you should create your 
			/// own implementation using a storage mechanism (eg database, cache) that is 
			/// accessible from multiple servers.
			DataAccessLayer.Repository = new AuthorisationAttemptRepository();
		}
	}
}
