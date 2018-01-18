using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.WPF
{
	public partial class UtilisateurVM : DTOBaseVM
	{
		public String Photo { get; set; }
		public String Nom { get; set; }
		public String Prenom { get; set; }
		public String Portable { get; set; }
		public String Email { get; set; }
		public String Login { get; set; }
		public String Pass { get; set; }
		public bool Archive { get; set; }
		public string Profils { get; set; }

	}
}
