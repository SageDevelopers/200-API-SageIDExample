using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SageID.ConfidentialClient;

namespace APISampleWebSite
{
	/// <summary>
	/// Specify implementation of AuthorisationAttemptRepository.
	/// Note: The sample implementation works only if your website is hosted on a 
	/// single server.
	/// If your website is hosted across multiple servers, you should create your 
	/// own implementation using a storage mechanism (eg database, cache) that is 
	/// accessible from multiple servers.
	/// </summary>
	public class AuthorisationAttemptRepository : IAuthorisationAttemptRepository
	{
		/// <summary>
		/// Dictionary holding authorisation attempts
		/// </summary>
		private Dictionary<string, AuthorisationAttempt> _authAttemptRepo = new Dictionary<string, AuthorisationAttempt>();

		/// <summary>
		/// Persists an authorisation code identifier along with the userId making
		/// the authorisation attempt.
		/// </summary>
		/// <param name="authAttempt">The authorisation attempt</param>
		public void Persist(AuthorisationAttempt authAttempt)
		{
			_authAttemptRepo.Add(authAttempt.AttemptIdentifier, authAttempt);
		}

		/// <summary>
		/// Gets the authorisation attempt from the persistant storage.
		/// </summary>
		/// <param name="attemptIdentifier">The authorisation attempt identifier</param>
		/// <returns>
		/// Null if the attempt could not be found, otherwise the authorisation attempt.
		/// </returns>
		public AuthorisationAttempt Get(string attemptIdentifier)
		{
			if (_authAttemptRepo.ContainsKey(attemptIdentifier))
			{
				return _authAttemptRepo[attemptIdentifier];
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Removes the authorisation attempt from the peristent storage.
		/// </summary>
		/// <param name="attemptIdentifier">The authorisation attempt identifier</param>
		public void Remove(string attemptIdentifier)
		{
			if (_authAttemptRepo.ContainsKey(attemptIdentifier))
			{
				_authAttemptRepo.Remove(attemptIdentifier);
			}
		}
	}
}