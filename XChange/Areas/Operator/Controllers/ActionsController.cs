using Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XChange.Areas.Operator.ViewModels;

namespace XChange.Areas.Operator.Controllers
{
	[RouteArea("Operator")]
    public class ActionsController : OperatorController
    {
        public ActionResult Sell()
        {
			return View(new SellViewModel(CurrentUser));
        }
		[HttpPost]
		public JsonResult Sell(int cashID, int currencyID, decimal price, decimal currWorth)
		{
			try
			{
				new SellViewModel(CurrentUser).Sell(cashID, currencyID, price, currWorth, CurrentUser.ID);
				return Json(new { result = true });
			}
			catch (ValidationException ex)
			{
				return Json(new { result = false, errors = ex.Errors });
			}
		}
	}
}