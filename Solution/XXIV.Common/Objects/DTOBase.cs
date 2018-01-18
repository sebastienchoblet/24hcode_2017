using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XXIV.Common.Objects
{
	[DataContract, Serializable]
	public class DTOBase
	{
		public DTOBase()
		{
			Id = Guid.NewGuid();
		}

		[DataMember]
		public Guid Id { get; set; }

		[DataMember]
		public Guid? CreePar { get; set; }

		[DataMember]
		public Guid? ModifiePar { get; set; }

		[DataMember]
		public DateTime DateDerniereModif { get; set; }

		[DataMember]
		public DateTime DateCreation { get; set; }

		#region Persistance
		public virtual void Fill(DataRow r)
		{
			Id = r.CGuid("Id");
			CreePar = r.CNullGuid("CreePar");
			ModifiePar = r.CNullGuid("ModifiePar");
			DateDerniereModif = r.CDateTime("DateDerniereModif");
			DateCreation = r.CDateTime("DateCreation");
		}

		public List<SqlParameter> BuildParameters()
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(Sql.Build("Id", Id));
			parameters.Add(Sql.Build("CreePar", CreePar));
			parameters.Add(Sql.Build("ModifiePar", ModifiePar));
			return parameters;
		}
		#endregion 
	}
}
