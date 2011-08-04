using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ApprovalUtilities.Persistence.Database
{
	public static class DatabaseUtils
	{
		public static List<T> Query<T>(string sql, string connection, Func<SqlDataReader, T> converter)
		{
			using (var conn = new SqlConnection(connection))
			{
				conn.Open();
				return Query(sql, conn.CreateCommand, converter);
			}
		}

		public static List<T> Query<T>(string sql, Func<SqlCommand> commandCreator, Func<SqlDataReader, T> converter)
		{
			using (var cmd = commandCreator())
			{
				cmd.CommandText = sql;
				using (var reader = cmd.ExecuteReader())
				{
					var r = new List<T>();
					while (reader.Read())
					{
						r.Add(converter(reader));
					}
					return r;
				}
			}
		}
	}
}