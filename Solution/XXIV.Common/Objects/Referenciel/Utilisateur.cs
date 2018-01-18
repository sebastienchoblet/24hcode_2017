using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{
	[Serializable, DataContract]
	public partial class Utilisateur : DTOBase
	{
		[DataMember]
		public String Photo { get; set; }
		[DataMember]
		public String Nom { get; set; }
		[DataMember]
		public String Prenom { get; set; }
		[DataMember]
		public String Portable { get; set; }
		[DataMember]
		public String Email { get; set; }
		[DataMember]
		public String Login { get; set; }
		[DataMember]
		public String Pass { get; set; }
		[DataMember]
		public bool Archive { get; set; }
		[DataMember]
		public UtilisateurProfil Profils { get; set; }

	}
}
