using System;
using System.Collections.Generic;
using Dapper;
using Models;

namespace Repositories.SQLRepositories
{
	public class CurrencyRepository : Abstracts.CurrencyRepository
	{
		public override IEnumerable<Currency> GetAllActive()
		{
			return Connection.Query<Currency>($"SELECT * FROM {nameof(Currency)} WHERE IsActive = 1");
		}
	}
}
