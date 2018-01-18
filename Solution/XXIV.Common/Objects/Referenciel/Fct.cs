using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{
	[Serializable, DataContract]
	public partial class Fct : DTOBase
	{
		[DataMember]
		public String Nom { get; set; }
		[DataMember]
		public String Description { get; set; }
		[DataMember]
		public DateTime DecableLe { get; set; }

		[DataMember]
		public Composant Composant { get; set; }
		[DataMember]
		public Fct FctParente { get; set; }
		[DataMember]
		public List<Evolution> Evolutions { get; set; }

	}
}
