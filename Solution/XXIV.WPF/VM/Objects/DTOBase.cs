using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XXIV.WPF
{
	public class DTOBaseVM : ViewModelBase
	{
		public DTOBaseVM()
		{
			Id = Guid.NewGuid();
		}
		public Guid Id { get; set; }
		public Guid? CreePar { get; set; }
		public Guid? ModifiePar { get; set; }
		public DateTime DateDerniereModif { get; set; }
		public DateTime DateCreation { get; set; }
	}
}
