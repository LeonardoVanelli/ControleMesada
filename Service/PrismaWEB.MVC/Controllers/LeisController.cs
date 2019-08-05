using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using PrismaWEB.Utils.Exception;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.Atributos;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class LeisController : Controller
    {
        private readonly ILeiAppService _leiApp;
        private readonly IPessoaAppService _pessoaApp;

        public LeisController(ILeiAppService leiApp, IPessoaAppService pessoaApp)
        {
            _leiApp = leiApp;
            _pessoaApp = pessoaApp;
        }

        // GET: Leis
        public ActionResult Index()
        {            
            var leiViewModel = Mapper.Map<IEnumerable<Lei>, IEnumerable<LeiViewModel>>(_leiApp.GetAll());
            return View(leiViewModel);
        }

        // GET: Leis/Details/5
        public ActionResult Details(int id)
        {
            var lei = _leiApp.GetById(id);
            var leiViewModel = Mapper.Map<Lei, LeiViewModel>(lei);
            return View(leiViewModel);
        }

        // GET: Leis/Create
        public ActionResult Create()
        {
            ViewBag.Autor_Id = new SelectList(_pessoaApp.GetAll(), "Id", "Nome");
            return View();
        }

        // POST: Leis/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeiViewModel lei)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var leiDomain = Mapper.Map<LeiViewModel, Lei>(lei);
                    _leiApp.Add(leiDomain);

                    return RedirectToAction("Index");
                }
            }
            catch (ListEntidadeException exps)
            {
                foreach (var exp in exps.Exceptions)
                {
                    ModelState.AddModelError(exp.NomeCampo, exp.Message);
                }
            }
            ViewBag.Autor_Id = new SelectList(_pessoaApp.GetAll(), "Id", "Nome");                
            return View(lei);
        }

        // GET: Leis/Edit/5
        public ActionResult Edit(int id)
        {
            var lei = _leiApp.GetById(id);
            var leiViewModel = Mapper.Map<Lei, LeiViewModel>(lei);

            return View(leiViewModel);
        }

        // POST: Leis/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeiViewModel lei)
        {
            if (ModelState.IsValid)
            {
                var leiDomain = Mapper.Map<LeiViewModel, Lei>(lei);
                _leiApp.Update(leiDomain);

                return RedirectToAction("Index");
            }

            return View(lei);
        }

        // GET: Leis/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _leiApp.Remove(_leiApp.GetById(id));
                return Json(404);
            }
            catch (Exception exp)
            {
                return Json(exp.Message);
            }
        }
    }
}
