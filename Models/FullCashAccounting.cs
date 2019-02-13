using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class FullCashAccounting
	{
		public CashAccounting CashAccounting { get; set; }
		public User User { get; set; }
		public Currency Currency { get; set; }
		public CashOperation CashOperation { get; set; }

		public bool IsPositiveOperation() => CashOperation.Sign > 0;
	}
}
