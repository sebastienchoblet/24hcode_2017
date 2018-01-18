using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.WPF
{
	public partial class FctVM : DTOBaseVM
	{
		public String Nom { get; set; }
		public String Description { get; set; }
		public DateTime DecableLe { get; set; }
		public Composant Composant { get; set; }
		public Fct FctParente { get; set; }
		public List<Evolution> Evolutions { get; set; }

	}
}
