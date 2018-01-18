using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.WPF
{
	public partial class ComposantVM : DTOBaseVM
	{
		public String Nom { get; set; }
		public String Description { get; set; }
		public Applicatif Applicatif { get; set; }
		public List<Fct> Fonctions { get; set; }

	}
}
