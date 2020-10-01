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
	public class Department
	{
		public long id;
		public string code;
		public string name;
	}
}
