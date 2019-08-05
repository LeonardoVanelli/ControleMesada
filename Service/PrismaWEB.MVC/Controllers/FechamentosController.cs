using PrismaWEB.Utils.Querys;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Application.Interface.Sistema;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class FechamentosController : Controller
    {
        private readonly IAtividadeAppService _atividadeApp;        
        private readonly IPessoaAppService _PessoaApp;           

        public FechamentosController(IAtividadeAppService atividadeApp, IPessoaAppService PessoaApp, IValorTarefaAppService ValorTarefaApp)
        {
            _atividadeApp = atividadeApp;
            _PessoaApp = PessoaApp;
        }

        // GET: Fechamentos
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Pessoa_Id = new SelectList(_PessoaApp.GetAll(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Index(FiltroFechamentoViewModel filtroFechamento)
        {
            if (ModelState.IsValid)
            {                
                TempData["atividades"] = _atividadeApp.RealizaFechamentoSemana(filtroFechamento.Pessoa_Id, filtroFechamento.Data);

                return RedirectToAction("Fechamento");
            }

            ViewBag.Pessoa_Id = new SelectList(_PessoaApp.GetAll(), "Id", "Nome");
            return View(filtroFechamento);
            
        }

        public ActionResult Fechamento()
        {
            var atividade = (IEnumerable<QueryReseult>)TempData["atividades"];
            return View(atividade);
        }
    }
}
