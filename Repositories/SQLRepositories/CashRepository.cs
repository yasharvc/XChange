using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Models;

namespace Repositories.SQLRepositories
{
	public class CashRepository : Abstracts.CashRepository
	{
		public override IEnumerable<Cash> GetUserCashes(int UserID) => Connection.Query<Cash>($"SELECT c.* FROM dbo.Cash c INNER JOIN dbo.Operator_Cash o ON c.ID = o.CashID INNER JOIN dbo.[User] u ON u.id = o.OperatorID WHERE u.ID = @id", new { id = UserID });
	}
}
