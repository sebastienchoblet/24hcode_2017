using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{
	[Serializable, DataContract]
	public partial class Utilisateur_Fct : DTOBase
	{
		[DataMember]
		public ConnaissancesType Connaissances { get; set; }
		[DataMember]
		public Double Niveau { get; set; }


	}

}
