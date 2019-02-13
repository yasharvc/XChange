using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public enum Operation:int
	{
		Charge = 1,
		Sell = 2,
		Buy = 3
	}
	public class CashOperation : BaseModel
	{
		public int ID { get; set; }
		public string Description { get; set; }
		public int Sign { get; set; }

		public Operation GetOperation() => (Operation)ID;

	}

}
