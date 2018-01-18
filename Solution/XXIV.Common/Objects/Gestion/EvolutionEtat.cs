using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{


	public enum EvolutionEtat
	{
		Brouillon = 0,
		Chiffrage = 1,
		Developpement = 2,
		Recette = 3,
		MisEnProd = 4,
	}
	public static class EvolutionEtatExt
	{
		public static string ToLabel(this EvolutionEtat p)
		{
			switch (p)
			{
				case EvolutionEtat.Brouillon:
					break;
				case EvolutionEtat.Chiffrage:
					break;
				case EvolutionEtat.Developpement:
					break;
				case EvolutionEtat.Recette:
					break;
				case EvolutionEtat.MisEnProd:
					break;
				default:
					break;
			}
			return p.ToString();
		}
	}


}