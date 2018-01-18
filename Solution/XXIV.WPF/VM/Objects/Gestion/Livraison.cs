using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.WPF
{
	public partial class LivraisonVM : DTOBaseVM
	{
		public String Titre { get; set; }
		public DateTime? MiseEnRecette { get; set; }
		public DateTime? DatePrevisionnelle { get; set; }
		public String Version { get; set; }
		public Applicatif Applicatif { get; set; }
		public List<Evolution> Evolutions { get; set; }

	}
}
