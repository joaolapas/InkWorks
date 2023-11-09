
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace InkWorks.Filters
{
    public class UtilizadorAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUtilizador = context.HttpContext.Session.GetString("sessaoUtilizador");

            if (string.IsNullOrEmpty(sessaoUtilizador))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "login" },
                    {"action", "Index" }
                });
            }
            else
            {
                Models.Utilizador user = JsonConvert.DeserializeObject<Models.Utilizador>(sessaoUtilizador);
                if (user == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "login" },
                    {"action", "Index" }
                });
                }
                else if (user.Perfil != InkWorks.Enums.PerfilEnum.Admin)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "login" },
                    {"action", "Index" }
                });

                }
            }

            base.OnActionExecuting(context);
        }


    }
}
