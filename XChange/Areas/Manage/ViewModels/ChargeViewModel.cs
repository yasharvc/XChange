using Business.Cash;
using Business.CashAccounting;
using Business.Currency;
using Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace XChange.Areas.Manage.ViewModels
{
	public class ChargeViewModel
	{
		public IEnumerable<Cash> Cashes { get; private set; }
		public IEnumerable<Currency> Currencies { get; private set; }
		public ChargeViewModel()
		{
			Cashes = new CashHandler().GetAll();
			Currencies = new CurrencyHandler().GetAllActive();
		}
		public bool Charge(int cashID, int currencyID, decimal price, decimal currWorth,int UserID)
		{
			return new CashAccountingHandler().Charge(cashID, currencyID, price, currWorth, UserID);
		}
	}
}