using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{
	[Serializable, DataContract]
	public partial class Tache : DTOBase
	{
		[DataMember]
		public String Titre { get; set; }
		[DataMember]
		public String Description { get; set; }
		[DataMember]
		public TacheType Type { get; set; }
		[DataMember]
		public TacheCriticite Criticite { get; set; }
		[DataMember]
		public Double ChargeDev { get; set; }
		[DataMember]
		public Double ChargeRecette { get; set; }

		[DataMember]
		public Fct Fct { get; set; }

	}

}
