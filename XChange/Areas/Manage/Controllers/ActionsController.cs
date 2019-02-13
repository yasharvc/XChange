using Business.Exceptions;
using System.Web.Mvc;
using XChange.Areas.Manage.ViewModels;

namespace XChange.Areas.Manage.Controllers
{
	[RouteArea("Manage")]
    public class ActionsController : ManagerController
    {
		[HttpGet]
        public ActionResult Charge()
        {
			return View(new ViewModels.ChargeViewModel());
        }
		[HttpPost]
		public JsonResult Charge(int cashID,int currencyID,decimal price,decimal currWorth)
		{
			try{
				new ChargeViewModel().Charge(cashID, currencyID, price, currWorth, CurrentUser.ID);
				return Json(new { result = true });
			}catch(ValidationException ex)
			{
				return Json(new { result = false, errors = ex.Errors });
			}
		}
    }
}