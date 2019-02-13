using System.Web.Mvc;

namespace XChange.Areas.Manage.Controllers
{
	public abstract class ManagerController : Controller
	{
		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (CurrentUser != null && CurrentUser.UserType == Models.UserType.Manager)
				base.OnActionExecuting(filterContext);
			else
			{
				filterContext.Result = Redirect($"/Security/Index");
			}
		}

		protected Models.User CurrentUser => Session["User"] as Models.User;
	}
}