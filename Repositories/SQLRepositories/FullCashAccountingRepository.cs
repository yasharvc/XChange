using System.Collections.Generic;
using Dapper;
using Models;

namespace Repositories.SQLRepositories
{
	public class FullCashAccountingRepository : Abstracts.FullCashAcccountingRepository
	{
		public override IEnumerable<FullCashAccounting> GetAll()
		{
			var conn = new DB().GetConnection();
			var query = "SELECT ca.*,u.*,cu.*,co.* FROM dbo.CashAccounting ca INNER JOIN dbo.[User] u ON u.ID = ca.UserID INNER JOIN dbo.Currency cu ON cu.Id = ca.CurrencyID INNER JOIN dbo.CashOperation co ON co.ID = ca.CashOperationID";
			return conn.Query<CashAccounting, User, Currency, CashOperation, FullCashAccounting>(query, (ca, u, cu, co)
				=>
			{
				return new FullCashAccounting { CashAccounting = ca, CashOperation = co, Currency = cu, User = u };
			});
		}
	}
}
