using ProjetoModeloDDD.MVC.ViewModels.Sistema;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjetoModeloDDD.MVC.Atributos
{
    public class RotaPersonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string controllerName = ((ReflectedActionDescriptor)filterContext.ActionDescriptor).ControllerDescriptor.ControllerName;

            if (ControllerEhLoginOuRest(controllerName))
                return;            

            var Usuario = (filterContext.HttpContext.Session.Contents["usuarioLogado"] as SCadastroUsuarioLogadoViewModel);
            var nomeAction = ((ReflectedActionDescriptor)filterContext.ActionDescriptor).ActionName;
            if (Usuario == null)
            {
                filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary
                {
                    { "controller", "Login" },
                    { "action", "Index" },
                    { "actn", nomeAction},
                    { "ctrl", controllerName},
                    { "area", string.Empty }
                });
                return;
            }

            if (Usuario.Papeis.Where(p => p.Nome == "Desenvolvedor").FirstOrDefault() != null || controllerName == "Error")
                return;

            if (!PapelPermitido.UsuarioTemAcesso(Usuario.Pessoa_Id, nomeAction, controllerName))
            {
                filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary
                {
                    { "controller", "Error" },
                    { "action", "SemPermicao" },
                    { "area", string.Empty }
                });
            }
        }

        private bool ControllerEhLoginOuRest(string controllerName)
        {                            
            if (controllerName == "Login" || controllerName.Substring(controllerName.Length - 4).ToUpper() == "REST")
                return true;
            return false;
        }
    }
}