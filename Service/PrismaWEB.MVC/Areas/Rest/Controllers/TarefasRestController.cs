using ProjetoModeloDDD.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Areas.Rest.Controllers
{
    public class TarefasRestController : Controller
    {
        private readonly ITarefaAppService _TarefaApp;

        public TarefasRestController(ITarefaAppService TarefaApp)
        {
            _TarefaApp = TarefaApp;
        }
        // GET: Rest/TarefasRest
        public JsonResult GetAll()
        {

            var tarefas = _TarefaApp.GetAll();
            return Json(tarefas, JsonRequestBehavior.AllowGet);
        }
    }
}
