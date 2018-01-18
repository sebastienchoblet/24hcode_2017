using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.WPF
{
	public partial class TacheVM : DTOBaseVM
	{
		public String Titre { get; set; }
		public String Description { get; set; }
		public string Type { get; set; }
		public string Criticite { get; set; }
		public Double ChargeDev { get; set; }
		public Double ChargeRecette { get; set; }
		public Fct Fct { get; set; }

	}

}
