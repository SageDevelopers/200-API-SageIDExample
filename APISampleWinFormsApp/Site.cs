using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISampleWinFormsApp
{
	/// <summary>
	/// Simple data class: serialized/deserialized via json 
	/// The definition of this class is found in the developer 
	/// documentation for the API.
	/// </summary>
	public class Site
	{
		public int company_id;
		public string company_name;
		public string site_id;
		public string site_name;
		public string site_short_name;
	}
}
