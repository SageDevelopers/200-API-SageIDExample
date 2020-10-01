Version History:

v3.0.2
Targets new versions of libraries.

v3.0.1
Targets new versions of libraries.
WinFormsApp now shows Http Status Codes on error.

v3.0
Updated to include examples of how to make async calls to the API.
The SageID.PublicClient and SageID.ConfidentialClient AuthenticationProvider
are no longer a static class. Instead it is an instance class that can be accessed via the AuthenticationSingleton classes. Refer to the 
documentation and sample downloads to view these changes.

v2.0
Fully commented all classes and methods.
Versions of all of all components set to 2.0.0.0 because we’re also changing the samples apps.
Three new libraries to simplify access to SageID and Sage API:
  APIClientLibrary.dll - Simplifies access to Sage API.
  SageID.PublicClient.dll - Simplifies access to SageID for WinForm Clients.
  SageID.ConfidentialCLient - Simplifies access to SageID for Web Sites.
Sample apps reference new libraries to simplify API access.

APISampleWebSite
----------------
Removed Sage ID specific classes from Web Site project.
Reference SageID.ConfidentialClient from Web Site project to simplify Sage ID.
Reference APIClientLibrary from Web Site project to simplify Sage API access.
Updated APISampleWebSite to use new simple API methods.

APISamplesWinFormApp
--------------------
Removed Sage ID specific classes from Win Forms project.
Reference SageID.PublicClient from Win Forms project to simplify Sage ID.
Reference APIClientLibrary from Win Forms project to simplify Sage API access.
Updated APISampleWinFormsApp to use new simple API methods.


v1.0
Initial Version
 