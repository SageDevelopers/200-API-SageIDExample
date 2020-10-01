using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SageID.ConfidentialClient;

namespace APISampleWebSite.Controllers
{
    /// <summary>
    /// Controller handling Sage ID Logon
    /// </summary>
	public class AccountController : Controller
    {
		/// <summary>
		/// Attempts logon to Sage ID
		/// </summary>
		/// <returns>ActionResult of type RedirectResult which redirects to Account/Authorise</returns>
		public ActionResult LogOn()
		{
			return new RedirectResult(AuthenticationProviderFactory.GetProvider().StartAuthorisation(this.Session));
		}

		/// <summary>
		/// Invoked by the SageID authorisation server at the end of an authorisation attempt.
		/// </summary>
		public ActionResult Authorise(string code, string state, string error, string error_description)
		{
			ActionResult result = null;

			if (!string.IsNullOrWhiteSpace(error))
			{
				//return AuthoriseFailure(error, error_description, state);
			}
			else
			{
				// Check we can get a token / refresh token from the authorisation
				if (AuthenticationProviderFactory.GetProvider().AuthoriseSuccess(this.Session, code, state))
				{
					result = RedirectToAction("Index", "Home");
				}
				else
				{
					result = View("Error");
				}
			}

			return result;
		}

    }
}