using Business.CrossDomain;
using Models;
using System.Collections.Generic;

namespace XChange.Areas.Manage.ViewModels
{
	public class SellerReportViewModel
	{
		public IEnumerable<FullCashAccounting> CashAccountingRows { get; private set; } = new List<FullCashAccounting>();

		public SellerReportViewModel()
		{
			CashAccountingRows = new FullCashAccountingHandler().GetAll();
		}
	}
	public static class SellerReportRow
	{
		public static string GetArrowWithW3CSS(this FullCashAccounting cashAccounting)
		{
			return $"<i class='fa fa-arrow-{(cashAccounting.IsPositiveOperation() ? "up w3-text-green" : "down w3-text-red")}'></i>";
		}
	}
}