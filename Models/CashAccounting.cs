using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class CashAccounting : BaseModel
	{
		public int ID { get; set; }

		public int CashID { get; set; }

		public int CurrencyID { get; set; }

		public int UserID { get; set; }

		public int CashOperationID { get; set; }

		public decimal Value { get; set; }

		public decimal CurrencyValueInRial { get; set; }

		public DateTime Date { get; set; }

		public TimeSpan Time { get; set; }

		public string ShamsiDate { get; set; }
	}
}
