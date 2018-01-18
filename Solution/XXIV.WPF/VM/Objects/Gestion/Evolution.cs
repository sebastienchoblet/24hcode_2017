using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.WPF
{
	public partial class EvolutionVM : DTOBaseVM
	{
		public string Etat { get; set; }
		public Livraison Livraison { get; set; }
		public Fct Fct { get; set; }
		public List<Evolution_Utilisateur> Utilisateurs { get; set; }

	}

}
