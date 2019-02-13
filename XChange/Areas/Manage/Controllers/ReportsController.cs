using System.Web.Mvc;
using XChange.Areas.Manage.ViewModels;

namespace XChange.Areas.Manage.Controllers
{
    public class ReportsController : ManagerController
    {
        public ActionResult SellChart()
        {
            return View(new SellerReportViewModel());
        }
    }
}