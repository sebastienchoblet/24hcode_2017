using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{
	[Serializable, DataContract]
	public partial class Tache_Event : DTOBase
	{
		[DataMember]
		public Int16 Etat { get; set; }
		[DataMember]
		public Tache_EventAction TypeAction { get; set; }
		[DataMember]
		public String Message { get; set; }
		[DataMember]
		public UtilisateurProfil Role { get; set; }
		[DataMember]
		public Double Consomme { get; set; }

		[DataMember]
		public Tache Tache { get; set; }
		[DataMember]
		public Utilisateur Utilisateur { get; set; }

	}

}
