using Dapper;
using Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace Repositories
{
	internal class DB
	{
		public SqlConnection GetConnection()
		{
			if (Debugger.IsAttached)
				return new SqlConnection(@"Data Source=.;Initial Catalog=Xchange;User ID=sa;password=123");
			else
				return new SqlConnection(@"Data Source=.\MSSQLSERVER2016;Initial Catalog=sandogda_db;User ID=sandogda_yashar;password=123!@#asd");
		}
	}

	internal static class SQLExtensions
	{
		public static bool Delete(this IDbConnection connection, BaseModel entity)
		{
			var affectedrows = connection.Execute($"DELETE FROM [{entity.GetTableName()}] WHERE [{entity.GetIDColumnName()}] = @Id", entity);
			return affectedrows > 0;
		}

		public static bool Insert(this IDbConnection connection,BaseModel entity)
		{
			var query = $"INSERT INTO [{entity.GetTableName()}] ({entity.GetColumnsListWithoutID()})OUTPUT INSERTED.[{entity.GetIDColumnName()}] VALUES({entity.GetColumnsListWithoutID("@")})";
			var id = connection.QuerySingle<int>(query, entity);
			entity.SetID(id);
			return id > 0;
		}

		private static int ExecuteWithEffectedRowsCount(IDbConnection connection, BaseModel entity, string query)
		{
			return connection.Execute(query, entity);
		}

		public static bool Update(this IDbConnection connection, BaseModel entity)
		{
			var query = $"UPDATE [{entity.GetTableName()}] SET {entity.GetUpdateColumnList()} WHERE [{entity.GetIDColumnName()}] = @{entity.GetIDColumnName()}";
			return ExecuteWithEffectedRowsCount(connection, entity, query) > 0;
		}
	}
}
