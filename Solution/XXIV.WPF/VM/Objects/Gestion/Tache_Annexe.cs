using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.WPF
{
	public partial class Tache_AnnexeVM : DTOBaseVM
	{
		public String Nom { get; set; }
		public String Path { get; set; }
		public Tache Tache { get; set; }

	}
}
