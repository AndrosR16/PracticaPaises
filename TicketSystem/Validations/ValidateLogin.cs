using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters; 

namespace TicketSystem.Validations
{
    public class ValidateLogin : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var username = context.HttpContext.Session.GetString("userName");
            var userrole = context.HttpContext.Session.GetString("userRole"); 

            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(userrole))
            {
                if(context.Controller is Controller controller)
                {
                    controller.TempData["Error"] = "Debe iniciar sesión antes de continuar"; 
                }

                context.Result = new RedirectToActionResult("Login", "Home", null);

            }

            base.OnActionExecuted(context); 

        }
    }
}