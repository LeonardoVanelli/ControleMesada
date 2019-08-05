using ProjetoModeloDDD.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Areas.Rest.Controllers
{
    public class FechamentoRestController : Controller
    {
        private readonly IAtividadeAppService _atividadeApp;
        public FechamentoRestController(IAtividadeAppService atividadeApp)
        {
            _atividadeApp = atividadeApp;
        }

        // GET: Rest/FechamentoRest
        public JsonResult GetAllOfWeek(DateTime data)
        {
            var atividades = _atividadeApp.RealizaFechamentoSemana(data);
            return Json(atividades, JsonRequestBehavior.AllowGet);
        }
    }
}