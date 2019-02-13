using System.Web.Mvc;

namespace XChange.Areas.Operator.Controllers
{
	public abstract class OperatorController : Controller
	{
		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (CurrentUser != null && CurrentUser.UserType == Models.UserType.Operator)
				base.OnActionExecuting(filterContext);
			else
			{
				filterContext.Result = Redirect($"/Security/Index");
			}
		}

		protected Models.User CurrentUser => Session["User"] as Models.User;
	}
}