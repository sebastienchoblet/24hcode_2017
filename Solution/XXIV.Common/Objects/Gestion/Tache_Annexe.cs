using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{
	[Serializable, DataContract]
	public partial class Tache_Annexe : DTOBase
	{
		[DataMember]
		public String Nom { get; set; }
		[DataMember]
		public String Path { get; set; }

		[DataMember]
		public Tache Tache { get; set; }

	}
}
