using APIClientLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SageID.PublicClient;

namespace APISampleWinFormsApp
{
	/// <summary>
	/// This class demonstrates how to use the API from a Win Forms app
	/// </summary>
	public partial class Form1 : Form
	{

		public Form1()
		{
			InitializeComponent();
		}

		private void buttonSites_Click(object sender, EventArgs e)
		{
			try
			{
				ResetForm();
				string json = GetSites();
				HandleSites(json);
			}
            catch (AggregateException ex)
            {
				HandleAggregateException(ex);
            }
			catch (APIClientException ex)
			{
				HandleAPIClientException(ex);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private async void buttonSitesAsync_Click(object sender, EventArgs e)
		{
			try
			{
				ResetForm();
				string json = await GetSitesAsync();
				HandleSites(json);
			}
			catch (APIClientException ex)
			{
				HandleAPIClientException(ex);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}


		private void buttonDepartments_Click(object sender, EventArgs e)
		{
			try
			{
				ResetForm();
				string json = GetDepartments();
				HandleDepartments(json);
			}
            catch (AggregateException ex)
            {
				HandleAggregateException(ex);
			}
			catch (APIClientException ex)
			{
				HandleAPIClientException(ex);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private async void buttonDepartmentsAsync_Click(object sender, EventArgs e)
		{
			try
			{
				ResetForm();
				string json = await GetDepartmentsAsync();
				HandleDepartments(json);
			}
			catch (APIClientException ex)
			{
				HandleAPIClientException(ex);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}


		private void buttonPostDept_Click(object sender, EventArgs e)
		{
			try
			{
				ResetForm();
				string body = CreateDepartment(textBoxCode.Text);
				string json = PostDepartment(body);
				ShowDepartment(json);
			}
            catch (AggregateException ex)
            {
				HandleAggregateException(ex);
            }
			catch (APIClientException ex)
			{
				HandleAPIClientException(ex);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private async void buttonPostDeptAsync_Click(object sender, EventArgs e)
		{
			try
			{
				ResetForm();
				string body = CreateDepartment(textBoxCode.Text);
				string json = await PostDepartmentAsync(body);
				ShowDepartment(json);
			}
			catch (APIClientException ex)
			{
				HandleAPIClientException(ex);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}


		private void ResetForm()
		{
			this.richTextBox1.Text = string.Empty;
		}

		/// <summary>
		/// Gets the sites available to this API user
		/// This sample uses a class based on the API documentation to get the results
		/// For an example how to dynamically access properties see GetDepartments()
		/// This is a Sage 200 API method and is not exposed on other API's
		/// </summary>
		private string GetSites()
		{
			// Create a new instance of the APIClient.
			// This sets up the required properties on the APIClient.
			// See the APIClientFactory for details of what is set.
			APIClient apiClient = APIClientFactory.CreateNew();

			// Make the Get call to the APIClient, pass in the url from the version onwards
			// e.g. https://api.columbus.sage.com/uk/sage200/accounts/v1/sites becomes 
			// v1/sites because the APIClient knows the base url for the API
			return apiClient.Get("v1/sites");
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
			APIClient apiClient = APIClientFactory.CreateNew();

			// Make the Get call to the APIClient, pass in the url from the version onwards
			// e.g. https://api.columbus.sage.com/uk/sage200/accounts/v1/sites becomes 
			// v1/sites because the APIClient knows the base url for the API
			return apiClient.GetAsync("v1/sites");
		}


		private void HandleSites(string json)
		{
			// The get returns the a list of sites available, so you can deserialise the 
			// response into an IEnumerable.
			// If an error occurs during the Get, an exception is raised.
			IEnumerable<Site> results = JsonConvert.DeserializeObject<IEnumerable<Site>>(json);

			StringBuilder sb = new StringBuilder();

			// Then you can iterate the response objects
			foreach (Site item in results)
			{
				string line = item.company_id + "," + item.company_name + "," + item.site_id + "," + item.site_name;
				sb.Append(line);
				sb.Append("\r\n");
			}

			this.richTextBox1.Text = sb.ToString();

			// We need to specify a company to use for each subsequent request
			// For the example we just select the last company from the list,
			// however you would more likely display a list of companies and allow
			// the user to select the required company from a list
			Site last = results.Last();

			// And set the company and site id properties on the APIClientFactory so they will
			// be sent as headers with subsequent requests.
			APIClientFactory.CompanyID = last.company_id.ToString();
			APIClientFactory.SiteID = last.site_id;
		}

		/// <summary>
		/// Gets a list of departments for the selected company
		/// This sample uses a dynamic object rather than a class to get the results
		/// For an example how to access properties via a class rather than dynamically see GetSites()
		/// </summary>
		private string GetDepartments()
		{
			// If the site id has not been set on the APIClientFactory then raise an exception.
			// Site id and company id are required headers on the majority of requests for the 
			// Sage 200 API, exceptions would include GetSites().
			// In the sample app, get site reads the companies that this user has 
			// access to and selects the last one to use as the default company.
			// While the get sites call is not required, you will need some method 
			// to identify the company id and site id to include in the request headers.
			// If you do not specify the Site ID and Company ID, a 401 - Unauthorized exception
			// will be thrown.
			if (string.IsNullOrEmpty(APIClientFactory.SiteID))
			{
				throw new Exception("Get Sites, before you can Get Departments");
			}

			// Create a new instance of the APIClient.
			// This sets up the required properties on the APIClient
			// See the APIClientFactory for details of what is set.
			APIClient apiClient = APIClientFactory.CreateNew();

			// Make the Get call to the APIClient, pass in the url from the version onwards
			// e.g. https://api.columbus.sage.com/uk/sage200/accounts/v1/departments becomes 
			// v1/departments because the APIClient knows the base url for the API
			return apiClient.Get("v1/departments");
		}

		/// <summary>
		/// Gets a list of departments for the selected company
		/// This sample uses a dynamic object rather than a class to get the results
		/// For an example how to access properties via a class rather than dynamically see GetSites()
		/// </summary>
		private Task<string> GetDepartmentsAsync()
		{
			// If the site id has not been set on the APIClientFactory then raise an exception.
			// Site id and company id are required headers on the majority of requests for the 
			// Sage 200 API, exceptions would include GetSites().
			// In the sample app, get site reads the companies that this user has 
			// access to and selects the last one to use as the default company.
			// While the get sites call is not required, you will need some method 
			// to identify the company id and site id to include in the request headers.
			// If you do not specify the Site ID and Company ID, a 401 - Unauthorized exception
			// will be thrown.
			if (string.IsNullOrEmpty(APIClientFactory.SiteID))
			{
				throw new Exception("Get Sites, before you can Get Departments");
			}

			// Create a new instance of the APIClient.
			// This sets up the required properties on the APIClient
			// See the APIClientFactory for details of what is set.
			APIClient apiClient = APIClientFactory.CreateNew();

			// Make the Get call to the APIClient, pass in the url from the version onwards
			// e.g. https://api.columbus.sage.com/uk/sage200/accounts/v1/departments becomes 
			// v1/departments because the APIClient knows the base url for the API
			return apiClient.GetAsync("v1/departments");
		}

		private void HandleDepartments(string json)
		{
			// The get returns the a list of departments as a JArray, so you can deserialise the response
			// If an error occurs during the Get, an exception is raised.
			var departments = JsonConvert.DeserializeObject<dynamic>(json);

			StringBuilder sb = new StringBuilder();

			// Iterate each JObject on the JArray and get the field name and value
			foreach(var item in departments)
			{
				bool first = true;
				foreach(JToken token in item.Children())
				{
					if (token is JProperty)
					{
						if (first)
						{
							first = false;
						}
						else
						{
							sb.Append(",");
						}
						JProperty prop = token as JProperty;
						string fieldNameAndValue = prop.Name + "=" + prop.Value;
						sb.Append(fieldNameAndValue);
					}
				}
				sb.Append("\r\n");
			}

			this.richTextBox1.Text = sb.ToString();
		}

		/// <summary>
		/// Adds a new department to the departments
		/// </summary>
		/// <param name="code">The department code to add</param>
		private string CreateDepartment(string code)
		{
			// If the site id has not been set on the APIClientFactory then raise an exception.
			// Site id and company id are required headers on the majority of requests for the 
			// Sage 200 API, exceptions would include GetSites().
			// In the sample app, get sites reads the companies that this user has 
			// access to and selects the last one to use as the default company.
			// While the get sites call is not required, you will need some method 
			// to identify the company id and site id to include in the request headers.
			// If you do not specify the Site ID and Company ID, a 401 - Unauthorized exception
			// will be thrown.
			if (string.IsNullOrEmpty(APIClientFactory.SiteID))
			{
				throw new Exception("Get Sites, before you can Post Department");
			}

			// Create a new department instance. The department class is based in the 
			// documentation indetifying the fields and field types from the developer 
			// documentation.
			Department dept = new Department();

			// set properties on the department
			dept.code = code;
			dept.name = code + " name";

			// The APIClient requires the body to be sent as a json string
			// so serialise the object to json.
			string body = JsonConvert.SerializeObject(dept);

			return body;
		}

		private string PostDepartment(string body)
		{
			// Create a new instance of the APIClient.
			// This sets up the required properties on the APIClient
			// See the APIClientFactory for details of what is set.
			APIClient apiClient = APIClientFactory.CreateNew();

			// Make the Post call to the APIClient, pass in the url from the version onwards
			// e.g. https://api.columbus.sage.com/uk/sage200/accounts/v1/departments becomes 
			// v1/departments because the APIClient knows the base url for the API
			return apiClient.Post("v1/departments", body);
		}

		private Task<string> PostDepartmentAsync(string body)
		{
			// Create a new instance of the APIClient.
			// This sets up the required properties on the APIClient
			// See the APIClientFactory for details of what is set.
			APIClient apiClient = APIClientFactory.CreateNew();

			// Make the Post call to the APIClient, pass in the url from the version onwards
			// e.g. https://api.columbus.sage.com/uk/sage200/accounts/v1/departments becomes 
			// v1/departments because the APIClient knows the base url for the API
			return apiClient.PostAsync("v1/departments", body);
		}

		private void ShowDepartment(string json)
		{
			// A post returns the object created (in this case a department) so you
			// can deserialise the response (if required).
			// If an error occurs during the Post, an exception is raised.
			Department item = JsonConvert.DeserializeObject<Department>(json);

			string line = item.id + "," + item.code + "," + item.name;

			this.richTextBox1.Text = line;
		}

		private void HandleAPIClientException(APIClientException ex)
		{
			// Display http Status and any underlying error
			MessageBox.Show("HttpStatus=" + (int)ex.StatusCode + ", " + ex.StatusCode.ToString() + "\nError=" + ex.Message);
		}

		private void HandleAggregateException(AggregateException ex)
		{
			string message = string.Empty;

			foreach (Exception innerEx in ex.InnerExceptions)
			{
				if (innerEx is APIClientException)
				{
					HandleAPIClientException((APIClientException)innerEx);
				}
				else
				{
					MessageBox.Show(innerEx.Message);
				}

				// handle only first
				break;
			}
		}
	}
}
