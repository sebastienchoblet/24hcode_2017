using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.WPF
{
	public partial class BugTrackerVM : DTOBaseVM
	{
		public String Logo { get; set; }
		public String Adresse { get; set; }
		public String Pass { get; set; }
		public string Type { get; set; }


	}
}
