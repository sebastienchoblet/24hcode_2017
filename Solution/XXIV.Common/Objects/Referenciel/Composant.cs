using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{
	[Serializable, DataContract]
	public partial class Composant : DTOBase
	{
		[DataMember]
		public String Nom { get; set; }
		[DataMember]
		public String Description { get; set; }

		[DataMember]
		public Applicatif Applicatif { get; set; }
		[DataMember]
		public List<Fct> Fonctions { get; set; }

	}
}
