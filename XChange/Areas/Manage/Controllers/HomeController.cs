using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XChange.Areas.Manage.Controllers
{
	[RouteArea("Manage")]
    public class HomeController : ManagerController
    {
        // GET: Manage/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}