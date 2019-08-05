using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class SPapeisAcoesController : Controller
    {
        private readonly ISPapeisAcoesAppService _spapeisacoesApp;
        private readonly ISAcaoAppService _sacaoApp;
        private readonly ISPapelAppService _spapeisApp;
        private readonly ISPaginaAppService _spaginasApp;


        public SPapeisAcoesController(ISPapeisAcoesAppService spapeisacoesApp,
                                      ISAcaoAppService sacaoApp,
                                      ISPapelAppService spapeisApp,
                                      ISPaginaAppService spaginasApp)
        {
            _spapeisacoesApp = spapeisacoesApp;
            _sacaoApp = sacaoApp;
            _spapeisApp = spapeisApp;
            _spaginasApp = spaginasApp;
        }

        // GET: SPapeisAcoess
        public ActionResult Index()
        {
            ViewBag.Pagina_Id = new SelectList(_spaginasApp.GetAll(), "Id", "Nome");
            ViewBag.Papel_Id = new SelectList(_spapeisApp.GetAll(), "Id", "Nome");
            return View();
        }

        // GET: SPapeisAcoess/Details/5
        public ActionResult Details(int id)
        {
            var spapeisacoes = _spapeisacoesApp.GetById(id);
            var spapeisacoesViewModel = Mapper.Map<SPapeisAcoes, SPapeisAcoesViewModel>(spapeisacoes);
            return View(spapeisacoesViewModel);
        }

        // GET: SPapeisAcoess/Create
        public ActionResult Create()
        {
            ViewBag.Pagina_Id = new SelectList(_spaginasApp.GetAll(), "Id", "Nome");
            ViewBag.Papel_Id = new SelectList(_spapeisApp.GetAll(), "Id", "Nome");
            return View();
        }

        // POST: SPapeisAcoess/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SPapeisAcoesViewModel spapeisacoes)
        {
            if (ModelState.IsValid)
            {
                var spapeisacoesDomain = Mapper.Map<SPapeisAcoesViewModel, SPapeisAcoes>(spapeisacoes);
                _spapeisacoesApp.Add(spapeisacoesDomain);

                return RedirectToAction("Index");
            }

            ViewBag.Pagina_Id = new SelectList(_spaginasApp.GetAll(), "Id", "Nome");
            ViewBag.Papel_Id = new SelectList(_spapeisApp.GetAll(), "Id", "Nome");
            return View(spapeisacoes);
        }

        // GET: SPapeisAcoess/Edit/5
        public ActionResult Edit(int id)
        {
            var spapeisacoes = _spapeisacoesApp.GetById(id);
            var spapeisacoesViewModel = Mapper.Map<SPapeisAcoes, SPapeisAcoesViewModel>(spapeisacoes);

            return View(spapeisacoesViewModel);
        }

        // POST: SPapeisAcoess/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SPapeisAcoesViewModel spapeisacoes)
        {
            if (ModelState.IsValid)
            {
                var spapeisacoesDomain = Mapper.Map<SPapeisAcoesViewModel, SPapeisAcoes>(spapeisacoes);
                _spapeisacoesApp.Update(spapeisacoesDomain);

                return RedirectToAction("Index");
            }

            return View(spapeisacoes);
        }

        // GET: SPapeisAcoess/Delete/5
        public ActionResult Delete(int id)
        {
            var spapeisacoes = _spapeisacoesApp.GetById(id);
            var spapeisacoesViewModel = Mapper.Map<SPapeisAcoes, SPapeisAcoesViewModel>(spapeisacoes);

            return View(spapeisacoesViewModel);
        }

        // POST: SPapeisAcoess/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var spapeisacoes = _spapeisacoesApp.GetById(id);

            _spapeisacoesApp.Remove(spapeisacoes);

            return RedirectToAction("Index");
        }

        public JsonResult BuscaAcaoPorPagina(int IdPagina, int idPapel)
        {
            var acoes = _sacaoApp.BuscaPorPagina(IdPagina);
            foreach (var acao in acoes)
            {
                acao.Ativa = _spapeisacoesApp.TemAcessoPorAcaoEPapel(acao.Id, idPapel);
            }
            return Json(acoes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AlteraPermicao(int paginaId, int acaoId, int papelId)
        {
            try
            {
                _spapeisacoesApp.AlteraPermicao(papelId, acaoId);
            }
            catch (System.Exception)
            {
            }
            return Json("Alteração bem sucedida", JsonRequestBehavior.AllowGet);
        }
    }
}

