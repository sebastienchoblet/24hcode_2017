using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.WPF
{
	public partial class BugTracker_TacheVM : DTOBaseVM
	{
		public string Type { get; set; }
		public String IdBugTracker { get; set; }
		public Tache Tache { get; set; }

	}
}
