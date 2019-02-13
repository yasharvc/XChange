using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Business.CrossDomain
{
	public class FullCashAccountingHandler
	{
		public IEnumerable<Models.FullCashAccounting> GetAll() => Repositories.RepositoryProvider.GetFullCashAcccountingRepository().GetAll();
	}

}
