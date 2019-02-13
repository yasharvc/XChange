using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Repositories.Abstracts
{
	public abstract class UserRepository : Repository<User>
	{
		public abstract User GetByUserName(string user, string password);
	}
}
