using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.WPF
{
	public partial class ApplicatifVM : DTOBaseVM
	{
		public String Nom { get; set; }
		public String Logo { get; set; }
		public List<Composant> Composants { get; set; }

	}
}
