using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Models;

namespace Repositories.SQLRepositories
{
	public class UserRepository : Abstracts.UserRepository
	{
		public override User GetByUserName(string user, string password)
		{
			password = (password.ToLower().StartsWith("0x") ? "" : "0x") + password;
			return Connection.QuerySingle<User>($"SELECT * FROM [User] WHERE UserName = @user AND Password = {password}", new { user });
		}
	}
}
