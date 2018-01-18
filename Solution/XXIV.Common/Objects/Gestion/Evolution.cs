using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{
	[Serializable, DataContract]
	public partial class Evolution : DTOBase
	{
		[DataMember]
		public EvolutionEtat Etat { get; set; }

		[DataMember]
		public Livraison Livraison { get; set; }
		[DataMember]
		public Fct Fct { get; set; }
		[DataMember]
		public List<Evolution_Utilisateur> Utilisateurs { get; set; }

	}

}
