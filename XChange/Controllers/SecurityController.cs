using Business.User;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XChange.Controllers
{
	public class SecurityController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public JsonResult Index(string u,string p)
		{
			try
			{
				var user = new UserHandler().GetUserByUsernamePassword(u, p);
				user.Password = new byte[0];
				Session["User"] = user;
				return Json(new { result = true, url = $"/{(user.UserType == UserType.Operator ? "Operator" : "Manage")}/Home/Index" });
			}
			catch(Exception ex)
			{
				var str = ex.Message;
				return Json(new { result = false, msg = "نام کاربری و یا رمز عبور اشتباه است" });
			}
		}
		public ActionResult Logout()
		{
			Session.Remove("User");
			return RedirectToAction("Index");
		}

		public string Connection()
		{
			try
			{

				var con = Debugger.IsAttached ?
					new SqlConnection(@"Data Source=.;Initial Catalog=Xchange;User ID=sa;password=123") :
					new SqlConnection(@"Data Source=.\MSSQLSERVER2016;Initial Catalog=sandogda_db;User ID=sandogda_yashar;password=123!@#asd");
				con.Open();
				var cmd = con.CreateCommand();
				cmd.CommandText = "SELECT COUNT(1) FROM CashAccounting";
				var cnt = cmd.ExecuteScalar();
				return cnt.ToString();
			}
			catch(Exception w)
			{
				return "<h1>" + w.Message + "</h1>";
			}
		}
	}
}