using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XXIV.Common
{
	public static class Sql
	{
		public static SqlConnection BuildConnection()
		{
			string sCnx = ConfigurationManager.AppSettings["cnx"];
			//if (!sCnx.ContainsUncaseSensitive("Connection Timeout="))
			//{
			//	if (!sCnx.EndsWith(";"))
			//		sCnx += ";";
			//	sCnx = "{0}Connection Timeout={1}".F(sCnx, DefaultTimeOut);
			//}
			return new SqlConnection(sCnx);
		}
		//public static void CloseIfNecessary(SqlConnection cnx)
		//{

		//}
		public static void Exec(SqlConnection oCnx, string sSql, CommandType tp, params SqlParameter[] parametres)
		{
			if (oCnx == null)
			{
				oCnx = BuildConnection();
			}
			bool bAutoClose = oCnx.State != ConnectionState.Open;
			try
			{
				if (bAutoClose)
					oCnx.Open();
				System.Data.SqlClient.SqlCommand cmd = oCnx.CreateCommand();
				cmd.CommandText = sSql;
				cmd.CommandType = tp;
				cmd.CommandTimeout = 5;
				if (parametres.Length > 0)
					cmd.Parameters.AddRange(parametres);

				cmd.ExecuteNonQuery();
			}
			finally
			{
				if (bAutoClose)
					oCnx.Close();
			}

		}
		public static DataTable Load(SqlConnection oCnx, string sSql, CommandType tp, params SqlParameter[] parametres)
		{
			if (oCnx == null)
			{
				oCnx = BuildConnection();
			}
			bool bAutoClose = oCnx.State != ConnectionState.Open;
			try
			{

				//lock (_oLock)
				//{
				if (bAutoClose)
					oCnx.Open();
				System.Data.SqlClient.SqlCommand cmd = oCnx.CreateCommand();
				cmd.CommandText = sSql;
				cmd.CommandType = tp;
				cmd.CommandTimeout = 5;
				if (parametres.Length > 0)
					cmd.Parameters.AddRange(parametres);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataSet ds = new DataSet();
				da.Fill(ds);
				da.Dispose();

				return ds.Tables[0];
				//}
			}
			finally
			{
				if (bAutoClose)
					oCnx.Close();
			}
		}


		#region Parametres construction
		public static SqlParameter Build(string sName, Guid sValue)
		{
			return new SqlParameter("@" + sName, SqlDbType.UniqueIdentifier)
			{
				Value = sValue
			};
		}
		public static SqlParameter Build(string sName, Guid? sValue)
		{
			return new SqlParameter("@" + sName, SqlDbType.UniqueIdentifier)
			{
				Value = sValue
			};
		}
		public static SqlParameter Build(string sName, string sValue)
		{
			return new SqlParameter("@" + sName, SqlDbType.VarChar)
			{
				Value = sValue
			};
		}
		public static SqlParameter Build(string sName, bool sValue)
		{
			return new SqlParameter("@" + sName, SqlDbType.Bit)
			{
				Value = sValue
			};
		}
		public static SqlParameter Build(string sName, bool? sValue)
		{
			return new SqlParameter("@" + sName, SqlDbType.Bit)
			{
				Value = sValue
			};
		}
		public static SqlParameter Build(string sName, DateTime sValue)
		{
			return new SqlParameter("@" + sName, SqlDbType.DateTime)
			{
				Value = sValue
			};
		}
		public static SqlParameter Build(string sName, DateTime? sValue)
		{
			return new SqlParameter("@" + sName, SqlDbType.DateTime)
			{
				Value = sValue
			};
		}
		public static SqlParameter Build(string sName, long sValue)
		{
			return new SqlParameter("@" + sName, SqlDbType.BigInt)
			{
				Value = sValue
			};
		}
		public static SqlParameter Build(string sName, long? sValue)
		{
			return new SqlParameter("@" + sName, SqlDbType.BigInt)
			{
				Value = sValue
			};
		}
		public static SqlParameter Build(string sName, double sValue)
		{
			return new SqlParameter("@" + sName, SqlDbType.Float)
			{
				Value = sValue
			};
		}
		public static SqlParameter Build(string sName, double? sValue)
		{
			return new SqlParameter("@" + sName, SqlDbType.Float)
			{
				Value = sValue
			};
		}
		public static SqlParameter Build(string sName, int sValue)
		{
			return new SqlParameter("@" + sName, SqlDbType.Int)
			{
				Value = sValue
			};
		}
		public static SqlParameter Build(string sName, int? sValue)
		{
			return new SqlParameter("@" + sName, SqlDbType.Int)
			{
				Value = sValue
			};
		}
		#endregion
		#region Chargement
		public static string CString(this System.Data.DataRow row, string sNom)
		{
			if (row[sNom] == DBNull.Value)
				return null;
			return System.Convert.ToString(row[sNom]);//.Replace("\b", " ");
		}
		public static T C<T>(this System.Data.DataRow row, Expression<Func<T>> propertyExpresion)
		{
			var property = (MemberExpression)propertyExpresion.Body;
			string sNom = property.Member.Name;
			if (row[sNom] == DBNull.Value)
				return default(T);
			return (T)row[sNom];
		}
		public static Guid CGuid(this System.Data.DataRow row, string sNom)
		{
			return Guid.Parse(row[sNom].ToString());
		}
		public static Guid? CNullGuid(this System.Data.DataRow row, string sNom)
		{
			if (row[sNom] == DBNull.Value)
				return null;
			return Guid.Parse(row[sNom].ToString());
		}
		public static double? CNullDouble(this System.Data.DataRow row, string sNom)
		{
			if (row[sNom] == DBNull.Value)
				return null;
			return System.Convert.ToDouble(row[sNom]);
		}
		public static decimal? CNullDecimal(this System.Data.DataRow row, string sNom)
		{
			return System.Convert.ToDecimal(row[sNom]);
		}
		public static double CDouble(this System.Data.DataRow row, string sNom)
		{
			if (row[sNom] == DBNull.Value)
				return 0;
			return System.Convert.ToDouble(row[sNom]);
		}
		public static float CFloat(this System.Data.DataRow row, string sNom)
		{
			if (row[sNom] == DBNull.Value)
				return 0;
			float f = 0;
			if (float.TryParse(row[sNom].ToString(), out f))
				return f;
			return 0;
		}
		public static float? CNullFloat(this System.Data.DataRow row, string sNom)
		{
			if (row[sNom] == DBNull.Value)
				return null;
			float f = 0;
			if (float.TryParse(row[sNom].ToString(), out f))
				return f;
			return null;
		}
		public static short CShort(this System.Data.DataRow row, string sNom)
		{
			if (row[sNom] == DBNull.Value)
				return 0;
			return System.Convert.ToInt16(row[sNom]);
		}
		public static decimal CDecimal(this System.Data.DataRow row, string sNom)
		{
			if (row[sNom] == DBNull.Value)
				return 0;
			return System.Convert.ToDecimal(row[sNom]);
		}
		public static int? CNullInt(this System.Data.DataRow row, string sNom)
		{
			if (row[sNom] == DBNull.Value)
				return null;
			return System.Convert.ToInt32(row[sNom]);
		}
		public static int CInt(this System.Data.DataRow row, string sNom)
		{
			if (row[sNom] == DBNull.Value)
				return 0;
			return System.Convert.ToInt32(row[sNom]);
		}
		public static long CLong(this System.Data.DataRow row, string sNom)
		{
			if (row[sNom] == DBNull.Value)
				return 0;
			return System.Convert.ToInt64(row[sNom]);
		}
		public static bool? CNullBool(this System.Data.DataRow row, string sNom)
		{
			if (row[sNom] == DBNull.Value)
				return null;
			return System.Convert.ToBoolean(row[sNom]);
		}
		public static bool CBool(this System.Data.DataRow row, string sNom)
		{
			if (row[sNom] == DBNull.Value)
				return false;
			return System.Convert.ToBoolean(row[sNom]);
		}
		public static DateTime? CNullDateTime(this System.Data.DataRow row, string sNom)
		{
			if (row[sNom] == DBNull.Value)
				return null;
			return System.Convert.ToDateTime(row[sNom]);
		}
		public static DateTime CDateTime(this System.Data.DataRow row, string sNom, DateTimeKind kind)
		{
			return new DateTime(row.CDateTime(sNom).Ticks, kind);
		}
		public static DateTime CDateTime(this System.Data.DataRow row, string sNom)
		{
			if (row[sNom] == DBNull.Value)
				return DateTime.MinValue;
			return System.Convert.ToDateTime(row[sNom]);
		}
		public static TEnum CEnum<TEnum>(this System.Data.DataRow row, string sNom)
			where TEnum : struct, IConvertible
		{
			int value = CInt(row, sNom);
			foreach (TEnum item in Enum.GetValues(typeof(TEnum)))
				if (item.ToInt32(null) == value)
					return item;
			return default(TEnum);
		}
		public static TEnum? CNullEnum<TEnum>(this System.Data.DataRow row, string sNom)
			where TEnum : struct, IConvertible
		{
			int? value = CNullInt(row, sNom);
			if (value.HasValue)
				foreach (TEnum item in Enum.GetValues(typeof(TEnum)))
				{
					if (item.ToInt32(null) == value.Value)
						return item;
				}
			return null;
		}
		#endregion

		public static DataRow LoadEntity(string ps, params SqlParameter[] sqlParameters)
		{
			DataTable dt = Load(null, ps, CommandType.StoredProcedure, sqlParameters);
			if (dt != null && dt.Rows.Count == 1)
				return dt.Rows[0];
			return null;
		}
	}
}
