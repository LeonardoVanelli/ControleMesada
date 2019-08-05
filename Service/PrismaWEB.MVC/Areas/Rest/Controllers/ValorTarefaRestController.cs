using ProjetoModeloDDD.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Areas.Rest.Controllers
{
    public class ValorTarefaRestController : Controller
    {
        private readonly IValorTarefaAppService _ValorTarefaApp;

        public ValorTarefaRestController(IValorTarefaAppService ValorTarefaApp)
        {
            _ValorTarefaApp = ValorTarefaApp;
        }
        // GET: Rest/ValorTarefaRest
        public JsonResult BuscaValorToralSemanaPorData(DateTime data)
        {
            double valorTotal = _ValorTarefaApp.BuscaValorTotalDaSemanaPorData(data);
            return Json(valorTotal, JsonRequestBehavior.AllowGet);
        }
    }
}