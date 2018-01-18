using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXIV.Common;
using XXIV.Common.Objects;

namespace XXIV.Server
{
    public static class Utilisateurs
    {
		public static Utilisateur LoadUser(Guid gUserAspNet)
		{
			Utilisateur us = new Utilisateur();
			DataRow r = Sql.LoadEntity("LoadUserFromAspNet", Sql.Build("IdAspNet", gUserAspNet));
			us.Fill(r);
			return us;
		}
    }
}
