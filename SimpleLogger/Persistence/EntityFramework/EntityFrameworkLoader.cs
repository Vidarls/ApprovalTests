using System;
using System.Data;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using ApprovalUtilities.Persistence.Database;

namespace ApprovalUtilities.Persistence.EntityFramework
{
	public abstract class EntityFrameworkLoader<QueryType, LoaderType, DatabaseContextType> : IExecutableQuery,
	                                                                                          ILoader<LoaderType>,
	                                                                                          IDisposable
		where DatabaseContextType : ObjectContext

	{
		private readonly Func<DatabaseContextType> dbCreator;
		private DatabaseContextType db;

		protected EntityFrameworkLoader(Func<DatabaseContextType> dbCreator)
		{
			this.dbCreator = dbCreator;
		}
		
		protected EntityFrameworkLoader(DatabaseContextType nonDisposableDatabaseContext)
		{
			db = nonDisposableDatabaseContext;
		}

		public DatabaseContextType GetDatabaseContext()
		{
			if (db == null)
			{
				db = dbCreator();
			}
			return db;
		}

		public string GetQuery()
		{
			var linq = ((ObjectQuery) GetLinqStatement());
			var sql = linq.ToTraceString();
			foreach (var p in linq.Parameters)
			{
				sql = sql.Replace("@" + p.Name, "\'" + p.Value.ToString() + "\'");
			}
			return sql;
		}

		public string ExecuteQuery(string query)
		{
			var conn = (SqlConnection) ((EntityConnection) db.Connection).StoreConnection;
			if (conn.State == ConnectionState.Closed)
			{
				conn.Open();
			}
			return SqlLoaderUtils.ExecuteQueryToDisplayString(query, null, conn.CreateCommand);
		}

		public abstract IQueryable<QueryType> GetLinqStatement();
		public abstract LoaderType Load();

		public void Dispose()
		{
			if (db != null && dbCreator != null)
			{
				db.Dispose();
			}
		}
	}
}