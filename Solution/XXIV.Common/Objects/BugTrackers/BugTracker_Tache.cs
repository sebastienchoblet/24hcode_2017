using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{
	[Serializable, DataContract]
	public partial class BugTracker_Tache : DTOBase
	{
		[DataMember]
		public BugTrackerTypes Type { get; set; }
		[DataMember]
		public String IdBugTracker { get; set; }

		[DataMember]
		public Tache Tache { get; set; }

	}
}
