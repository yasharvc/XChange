using Business.Cash;
using Business.CashAccounting;
using Business.Currency;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XChange.Areas.Operator.ViewModels
{
	public class SellViewModel
	{
		public IEnumerable<Cash> Cashes { get; private set; }
		public IEnumerable<Currency> Currencies { get; private set; }
		public SellViewModel(User User)
		{
			Cashes = new CashHandler().GetUserCashes(User.ID);
			Currencies = new CurrencyHandler().GetAllActive();
		}

		public bool Sell(int cashID, int currencyID, decimal price, decimal currWorth, int UserID)
		{
			return new CashAccountingHandler().Sell(cashID, currencyID, price, currWorth, UserID);
		}
	}
}