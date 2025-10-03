using Microsoft.AspNetCore.Mvc.Filters;

namespace Bootcamp4_AspMVC.Filters
{
    public class SessionAuthorizeAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var email = context.HttpContext.Session.GetString("UserEmail");
            if (email == null)
            {
                context.HttpContext.Response.Redirect("/Account/Login");
            }


            base.OnActionExecuting(context);
        }

    }
}
