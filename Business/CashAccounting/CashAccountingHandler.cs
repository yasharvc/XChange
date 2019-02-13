using Business.CashAccounting.Validations;
using Models;
using Repositories;
using System;
using System.Globalization;

namespace Business.CashAccounting
{
	public class CashAccountingHandler : ModelHandler<Models.CashAccounting>
	{
		public CashAccountingHandler() : this(RepositoryProvider.GetCashAccountingRepository()) { }
		public CashAccountingHandler(IRepository<Models.CashAccounting> repository) : base(repository) {
			AddInsertValidation(
				new ValueIsNegativeValidation(),
				new RialPriceIsNegativeValidation());
		}

		public bool Charge(int cashID, int currencyID, decimal price, decimal currWorth, int UserID)
		{
			PrepareEntity(cashID, currencyID, price, currWorth, UserID);
			Entity.CashOperationID = (int)Operation.Charge;
			return Insert();
		}

		public bool Sell(int cashID, int currencyID, decimal price, decimal currWorth, int UserID)
		{
			PrepareEntity(cashID, currencyID, price, currWorth, UserID);
			Entity.CashOperationID = (int)Operation.Sell;
			return Insert();
		}

		private void PrepareEntity(int cashID, int currencyID, decimal price, decimal currWorth, int UserID)
		{
			var calendar = new PersianCalendar();
			var now = DateTime.Now;
			var shamsi = string.Format("{0}/{1:00}/{2:00}", calendar.GetYear(now), calendar.GetMonth(now), calendar.GetDayOfMonth(now));
			Entity.CurrencyID = currencyID;
			Entity.CurrencyValueInRial = currWorth;
			Entity.CashID = cashID;
			Entity.ShamsiDate = shamsi;
			Entity.UserID = UserID;
			Entity.Value = price;
			Entity.Date = now;
			Entity.Time = now.TimeOfDay;
		}
	}
}
