using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APISampleWebSite.Models
{
	/// <summary>
	/// Simple data class: serialized/deserialized via json 
	/// </summary>
	public class Department
	{
		public long id;
		public string code;
		public string name;
	}
}