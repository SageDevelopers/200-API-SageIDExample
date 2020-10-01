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
	/// Departments Controller
	/// Attribute to check there is a valid site
	/// </summary>
	[RequiresValidSite]
    public class DepartmentsController : Controller
    {
		/// <summary>
		/// GET: Departments Async
		/// </summary>
		/// <returns>View representing departments</returns>
		public async Task<ActionResult> Index()
        {
			string json = await GetDepartmentsAsync();

			IEnumerable<Department> items = JsonConvert.DeserializeObject<IEnumerable<Department>>(json);

			return View(items);
		}

		/// <summary>
		/// Gets a list of departments for the selected company
		/// This sample uses a dynamic object rather than a class to get the results
		/// For an example how to access properties via a class rather than dynamically see GetSites()
		/// </summary>
		private Task<string> GetDepartmentsAsync()
		{
			// Create a new instance of the APIClient.
			// This sets up the required properties on the APIClient
			// See the APIClientFactory for details of what is set.
			APIClient apiClient = APIClientFactory.CreateNew(Session);

			// Make the Get call to the APIClient, pass in the url from the version onwards
			// e.g. https://api.columbus.sage.com/uk/sage200/accounts/v1/departments becomes 
			// v1/departments because the APIClient knows the base url for the API
			return apiClient.GetAsync("v1/departments");
		}
	}
}