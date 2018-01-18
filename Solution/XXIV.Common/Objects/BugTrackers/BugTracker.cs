using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{
	[Serializable, DataContract]
	public partial class BugTracker : DTOBase
	{
		[DataMember]
		public String Logo { get; set; }
		[DataMember]
		public String Adresse { get; set; }
		[DataMember]
		public String Pass { get; set; }
		[DataMember]
		public BugTrackerTypes Type { get; set; }
	}
}
