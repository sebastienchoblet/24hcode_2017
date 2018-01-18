using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{

	public enum TacheCriticite
	{
		Nondefini = 0,
		Normal = 1,
		Urgent = 2,
		Critique = 3,
	}

	public static class TacheCriticiteExt
	{
		public static string ToLabel(this TacheCriticite p)
		{
			switch (p)
			{
				case TacheCriticite.Nondefini:
					break;
				case TacheCriticite.Normal:
					break;
				case TacheCriticite.Urgent:
					break;
				case TacheCriticite.Critique:
					break;
				default:
					break;
			}
			return p.ToString();
		}
	}

}