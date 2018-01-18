using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace XXIV.Common.Objects
{

	public enum Tache_EventAction
	{
		Aucun = 0,
		Commentaire = 1,

	}

	public static class Tache_EventActionExt
	{
		public static string ToLabel(this Tache_EventAction p)
		{
			switch (p)
			{
				case Tache_EventAction.Aucun:
					break;
				case Tache_EventAction.Commentaire:
					break;
				default:
					break;
			}
			
			return p.ToString();
		}
	}

}