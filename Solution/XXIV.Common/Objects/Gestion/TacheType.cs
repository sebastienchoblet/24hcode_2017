using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{
	public enum TacheType
	{
		Bug = 1,
		Evolution = 2
	}

	public static class TacheTypeExt
	{

		public static string ToLabel(this TacheType p)
		{
			switch (p)
			{
				case TacheType.Bug:
					break;
				case TacheType.Evolution:
					break;
				default:
					break;
			}
			
			return p.ToString();
		}
	}


}