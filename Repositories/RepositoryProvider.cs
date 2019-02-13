using Repositories.SQLRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public static class RepositoryProvider
	{
		public static Abstracts.UserRepository GetUserRepository() => new UserRepository();
		public static Abstracts.CashRepository GetCashRepository() => new CashRepository();
		public static Abstracts.CurrencyRepository GetCurrencyRepository() => new CurrencyRepository();
		public static Abstracts.CashAccountingRepository GetCashAccountingRepository() => new CashAccountingRepository();
		public static Abstracts.FullCashAcccountingRepository GetFullCashAcccountingRepository() => new FullCashAccountingRepository(); 
	}
}
