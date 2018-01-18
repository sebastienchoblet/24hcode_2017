using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXIV.Common.Objects
{
	[Flags]
	public enum UtilisateurProfil
	{
		Aucun = 0,
		Admin = 2,
		Developpeur = 4,
		Recetteur = 8,
		CP = 16

	}

	public static class UtilisateurProfilExt
	{
		public static string ToLabel(this UtilisateurProfil p)
		{
			switch (p)
			{
				case UtilisateurProfil.Aucun:
					break;
				case UtilisateurProfil.Admin:
					break;
				case UtilisateurProfil.Developpeur:
					break;
				case UtilisateurProfil.Recetteur:
					break;
				case UtilisateurProfil.CP:
					break;
				default:
					break;
			}
			return p.ToString();
		}
	}
}
