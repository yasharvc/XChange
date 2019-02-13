using Repositories;
using Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Business.Cash
{
	public class CashHandler : ModelHandler<Models.Cash>
	{
		public CashHandler() : base(RepositoryProvider.GetCashRepository()) { }
		public CashHandler(IRepository<Models.Cash> repository) : base(repository) { }

		public IEnumerable<Models.Cash> GetUserCashes(int UserID)
		{
			return ((CashRepository)Repository).GetUserCashes(UserID);
		}
	}
}
