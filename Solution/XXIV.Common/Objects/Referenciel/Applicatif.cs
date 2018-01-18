using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{
	[Serializable, DataContract]
	public partial class Applicatif : DTOBase
	{
		[DataMember]
		public String Nom { get; set; }
		[DataMember]
		public String Logo { get; set; }

		[DataMember]
		public List<Composant> Composants { get; set; }

	}
}
