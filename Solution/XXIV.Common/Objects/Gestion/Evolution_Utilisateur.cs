using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{
	[Serializable, DataContract]
	public partial class Evolution_Utilisateur : DTOBase
	{
		[DataMember]
		public UtilisateurProfil Roles { get; set; }
		[DataMember]
		public Double ChargeDev { get; set; }
		[DataMember]
		public Double ChargeRecette { get; set; }

		[DataMember]
		public Evolution Evolution { get; set; }
		[DataMember]
		public Utilisateur Utilisateur { get; set; }

	}
}
