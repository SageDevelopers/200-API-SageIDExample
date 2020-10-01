using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace APISampleWebSite
{
	/// <summary>
	/// Checks that user has selected Site/Company
	/// This attribute validates that user has selected a site/company, and 
	/// redirects to Select Sites page if not.
	/// Apply this attribute to all controllers where you expect the user to 
	/// already have selected a site.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class RequiresValidSiteAttribute : ActionFilterAttribute
	{
		/// <summary>
		/// Checks that site ID and company ID are set on the session
		/// Executed on all controllers with RequiresValidSiteAttribute
		/// </summary>
		/// <param name="filterContext">The ActionExecutingContext</param>
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);

			string returnurl = string.Empty;

			try
			{
				// Set the return URL to the request URL
				returnurl = filterContext.HttpContext.Request.Url.AbsolutePath;
			}
			catch
			{
			}

			HttpRequestBase request = filterContext.HttpContext.Request;

			try
			{
				// Check the site ID and Company ID are set on the session, 
				// if not then redirect to the index page
				if (ContextStore.IsValid(filterContext.HttpContext.Session) == false)
				{
					filterContext.Result = new RedirectToRouteResult(
											new RouteValueDictionary(
												new
												{
													controller = "Sites",
													action = "Index",
													ReturnUrl = returnurl
												}));
				}
			}
			catch (Exception)
			{
				{
					// force re-logon
					ContextStore.Reset(filterContext.HttpContext.Session);

					filterContext.Result = new System.Web.Mvc.HttpUnauthorizedResult();
				}
			}
		}
	}
}