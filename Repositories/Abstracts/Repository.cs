using Dapper;
using Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repositories.Abstracts
{
	public abstract class Repository<T> : IRepository<T> where T : BaseModel, new()
	{
		protected SqlConnection Connection => new DB().GetConnection();
		public virtual bool Delete(T entry) => Connection.Delete(entry);
		public IEnumerable<T> GetAll() => Connection.Query<T>($"SELECT * FROM [{new T().GetTableName()}]");
		public T GetByID(int ID)
		{
			var temp = new T();
			return Connection.QuerySingle<T>($"SELECT * FROM [{temp.GetTableName()}] WHERE [{temp.GetIDColumnName()}] = @id",new { id = ID });
		}
		public bool Insert(T entry) => Connection.Insert(entry);
		public bool Update(T entry) => Connection.Update(entry);
	}
}
