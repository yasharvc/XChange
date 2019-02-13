using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstracts
{
	public abstract class CashRepository : Repository<Cash>
	{
		public abstract IEnumerable<Cash> GetUserCashes(int UserID);
	}
}
