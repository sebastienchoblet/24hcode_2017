using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.WPF
{
	public partial class Tache_EventVM : DTOBaseVM
	{
		public Tache_EventEtat Etat { get; set; }
		public string TypeAction { get; set; }
		public String Message { get; set; }
		public string Role { get; set; }
		public Double Consomme { get; set; }
		public Tache Tache { get; set; }
		public Utilisateur Utilisateur { get; set; }

	}

}
