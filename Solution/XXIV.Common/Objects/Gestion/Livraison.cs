using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{
	[Serializable, DataContract]
	public partial class Livraison : DTOBase
	{
		[DataMember]
		public String Titre { get; set; }
		[DataMember]
		public DateTime? MiseEnRecette { get; set; }
		[DataMember]
		public DateTime? DatePrevisionnelle { get; set; }
		[DataMember]
		public String Version { get; set; }

		[DataMember]
		public Applicatif Applicatif { get; set; }
		[DataMember]
		public List<Evolution> Evolutions { get; set; }

	}
}
