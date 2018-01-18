using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{

	[Flags]
	public enum ConnaissancesType
	{
		Aucune = 0,
		Fonctionnelle = 2,
		Code = 4,
	}


	public static class ConnaissancesTypeExt
	{
		public static string ToLabel(this ConnaissancesType p)
		{
			switch (p)
			{
				case ConnaissancesType.Aucune:
					break;
				case ConnaissancesType.Fonctionnelle:
					break;
				case ConnaissancesType.Code:
					break;
				default:
					break;
			}
			return p.ToString();
		}
	}

}