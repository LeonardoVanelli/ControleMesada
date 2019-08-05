using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Enum;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly IPessoaAppService _pessoaApp;

        public CandidatoController(IPessoaAppService pessoaApp)
        {
            _pessoaApp = pessoaApp;
        }

        // GET: Pessoas
        public ActionResult Index()
        {
            var pessoaViewModel = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<CandidatoViewModel>>(_pessoaApp.ObterCandidatos());
            return View(pessoaViewModel);
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int id)
        {
            var pessoa = _pessoaApp.GetById(id);
            var pessoaViewModel = Mapper.Map<Pessoa, CandidatoViewModel>(pessoa);
            return View(pessoaViewModel);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            ViewBag.Pais_Id = null;
            ViewBag.Estado_Id = null;
            ViewBag.Cidade_Id = null;
            ViewBag.Bairro_Id = null;
            ViewBag.Logradouro_Id = null;
            return View();
        }

        // POST: Pessoas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CandidatoViewModel pessoa)
        {            
            if (ModelState.IsValid)
            {
                var pessoaDomain = Mapper.Map<CandidatoViewModel, Pessoa>(pessoa);
                pessoaDomain.Tipo = new TipoPessoa();
                _pessoaApp.Add(pessoaDomain);

                return RedirectToAction("Index");
            }

            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int id)
        {
            var pessoa = _pessoaApp.GetById(id);
            var pessoaViewModel = Mapper.Map<Pessoa, CandidatoViewModel>(pessoa);

            return View(pessoaViewModel);
        }

        // POST: Pessoas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CandidatoViewModel pessoa)
        {
            if (ModelState.IsValid)
            {
                var pessoaDomain = Mapper.Map<CandidatoViewModel, Pessoa>(pessoa);
                _pessoaApp.Update(pessoaDomain);

                return RedirectToAction("Index");
            }

            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int id)
        {
            var pessoa = _pessoaApp.GetById(id);
            var pessoaViewModel = Mapper.Map<Pessoa, CandidatoViewModel>(pessoa);

            return View(pessoaViewModel);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var pessoa = _pessoaApp.GetById(id);

            _pessoaApp.Remove(pessoa);

            return RedirectToAction("Index");
        }
    }
}

