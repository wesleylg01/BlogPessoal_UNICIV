using BlogPessoal.Web.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogPessoal.Web.Filtros
{
    public class ExibirArtigosActionFilter : ActionFilterAttribute 
    {
        private BlogPessoalContexto db = new BlogPessoalContexto();

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var artigos = db.Artigos
                //.Where(t => t.Titulo == "Nossa Mano")
                .OrderByDescending(t => t.DataPublicacao)
                .Take(3)
                .ToList();

            filterContext.Controller.ViewBag.Artigos = artigos;
            base.OnResultExecuting(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            var message = string.Format("{0} controller: {1} action: {2}", "onactionexecuting", controllerName, actionName);

            Debug.WriteLine(message, "Action Filter Log");

            base.OnActionExecuting(filterContext);
        }
    }
}