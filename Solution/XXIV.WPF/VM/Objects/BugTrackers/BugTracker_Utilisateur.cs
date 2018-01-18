using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.WPF
{
	public partial class BugTracker_UtilisateurVM : DTOBaseVM
	{
		public String Login { get; set; }
		public String Pass { get; set; }
		public string Type { get; set; }
		public String IdBugTracker { get; set; }
		public Utilisateur Utilisateur { get; set; }

	}

}
