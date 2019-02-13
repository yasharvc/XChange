using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Repositories.Abstracts;

namespace Repositories
{
	public abstract class CashOperationRepository : Repository<CashOperation>
	{
	}
}
