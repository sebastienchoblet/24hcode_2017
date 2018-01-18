using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{
	[Serializable, DataContract]
	public partial class BugTracker_Utilisateur : DTOBase
	{
		[DataMember]
		public String Login { get; set; }
		[DataMember]
		public String Pass { get; set; }
		[DataMember]
		public BugTrackerTypes Type { get; set; }
		[DataMember]
		public String IdBugTracker { get; set; }

		[DataMember]
		public Utilisateur Utilisateur { get; set; }

	}

}
