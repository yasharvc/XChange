using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XChange.Areas.Operator.Controllers
{
	[RouteArea("Operator")]
    public class HomeController : OperatorController
    {
        // GET: Operator/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}