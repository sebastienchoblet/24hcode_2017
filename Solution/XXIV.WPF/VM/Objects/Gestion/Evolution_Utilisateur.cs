using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.WPF
{
	public partial class Evolution_UtilisateurVM : DTOBaseVM
	{
		public string Roles { get; set; }
		public Double ChargeDev { get; set; }
		public Double ChargeRecette { get; set; }
		public Evolution Evolution { get; set; }
		public Utilisateur Utilisateur { get; set; }

	}
}
