using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{

	public enum BugTrackerTypes
	{
		NonDefini = 0,
		Bugzilla = 1,
		Flyspray = 2,
		Redmind = 3,
		TFS = 4
	}



	public static class BugTrackerTypesExt
	{
		public static string ToLabel(this BugTrackerTypes p)
		{
			switch (p)
			{
				case BugTrackerTypes.NonDefini:
					break;
				case BugTrackerTypes.Bugzilla:
					break;
				case BugTrackerTypes.Flyspray:
					break;
				case BugTrackerTypes.Redmind:
					break;
				case BugTrackerTypes.TFS:
					break;
				default:
					break;
			}
		
			return p.ToString();
		}
	}

}