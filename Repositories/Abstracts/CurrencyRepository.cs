using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstracts
{
	public abstract class CurrencyRepository:Repository<Currency>
	{
		public abstract IEnumerable<Currency> GetAllActive();
	}
}
