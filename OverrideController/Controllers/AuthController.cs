using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace OverrideController.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Query["token"] != "qwerty")
            {
                context.HttpContext.Response.WriteAsync("Auth error. Need token. Sample request?token=qwerty");
            }

            base.OnActionExecuting(context);
        }
    }
}
