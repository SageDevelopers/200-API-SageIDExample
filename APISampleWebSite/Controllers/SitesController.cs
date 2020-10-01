using APIClientLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using APISampleWebSite.Models;


namespace APISampleWebSite.Controllers
{
	/// <summary>
	/// Sites Controller
	/// Attributed to check there is a valid logon
	/// </summary>
	[RequiresValidLogon]
    public class SitesController : Controller
    {
		/// <summary>
		/// GET: Sites Async
		/// </summary>
		/// <returns>View representing Sites</returns>
		public async Task<ActionResult> Index()
        {
			string json = await GetSitesAsync();

			IEnumerable<Site> sites = JsonConvert.DeserializeObject<IEnumerable<Site>>(json);

			// We need to specify a company to use for each subsequent request
			// For the example we just select the last company from the list,
			// however you would more likely display a list of companies and allow
			// the user to select the required company from a list
			Site site = sites.Last<Site>();
			// Set the site and company on the session
			ContextStore.Set(Session, site.site_id, site.company_id.ToString());

			return View(sites);
		}

		/// <summary>
		/// Gets the sites available to this API user
		/// This sample uses a class based on the API documentation to get the results
		/// For an example how to dynamically access properties see GetDepartments()
		/// This is a Sage 200 API method and is not exposed on other API's
		/// </summary>
		private Task<string> GetSitesAsync()
		{
			// Create a new instance of the APIClient.
			// This sets up the required properties on the APIClient.
			// See the APIClientFactory for details of what is set.
			APIClient apiClient = APIClientFactory.CreateNew(Session);

			// Make the Get call to the APIClient, pass in the url from the version onwards
			// e.g. https://api.columbus.sage.com/uk/sage200/accounts/v1/sites becomes 
			// v1/sites because the APIClient knows the base url for the API
			return apiClient.GetAsync("v1/sites");
		}
	}
}