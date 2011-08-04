using System;
using System.Data.SqlClient;

namespace ApprovalUtilities.Persistence.Database
{
	public abstract class SqlLoader<T> : ILoader<T>, IExecutableQuery
	{
		public readonly Func<SqlCommand> CommandCreator;
		public readonly string ConnectionString;

		protected SqlLoader(string connectionString)
		{
			this.ConnectionString = connectionString;
		}

		protected SqlLoader(Func<SqlCommand> commandCreator)
		{
			this.CommandCreator = commandCreator;
		}

		public abstract T Load();

		public abstract string GetQuery();

		public string ExecuteQuery(string query)
		{
			return SqlLoaderUtils.ExecuteQueryToDisplayString(query, ConnectionString, CommandCreator);
		}
	}
}