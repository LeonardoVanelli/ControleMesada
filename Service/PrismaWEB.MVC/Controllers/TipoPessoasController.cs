using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class TipoPessoasController : Controller
    {
        private readonly ITipoPessoaAppService _tipopessoaApp;

        public TipoPessoasController(ITipoPessoaAppService tipopessoaApp)
        {
            _tipopessoaApp = tipopessoaApp;
        }

        // GET: TipoPessoas
        public ActionResult Index()
        {
            var tipopessoaViewModel = Mapper.Map<IEnumerable<TipoPessoa>, IEnumerable<TipoPessoaViewModel>>(_tipopessoaApp.GetAll());
            return View(tipopessoaViewModel);
        }

        // GET: TipoPessoas/Details/5
        public ActionResult Details(int id)
        {
            var tipopessoa = _tipopessoaApp.GetById(id);
            var tipopessoaViewModel = Mapper.Map<TipoPessoa, TipoPessoaViewModel>(tipopessoa);
            return View(tipopessoaViewModel);
        }

        // GET: TipoPessoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPessoas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoPessoaViewModel tipopessoa)
        {
            if (ModelState.IsValid)
            {
                var tipopessoaDomain = Mapper.Map<TipoPessoaViewModel, TipoPessoa>(tipopessoa);
                _tipopessoaApp.Add(tipopessoaDomain);

                return RedirectToAction("Index");
            }

            return View(tipopessoa);
        }

        // GET: TipoPessoas/Edit/5
        public ActionResult Edit(int id)
        {
            var tipopessoa = _tipopessoaApp.GetById(id);
            var tipopessoaViewModel = Mapper.Map<TipoPessoa, TipoPessoaViewModel>(tipopessoa);

            return View(tipopessoaViewModel);
        }

        // POST: TipoPessoas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoPessoaViewModel tipopessoa)
        {
            if (ModelState.IsValid)
            {
                var tipopessoaDomain = Mapper.Map<TipoPessoaViewModel, TipoPessoa>(tipopessoa);
                _tipopessoaApp.Update(tipopessoaDomain);

                return RedirectToAction("Index");
            }

            return View(tipopessoa);
        }
        
        public JsonResult Delete(int id)
        {
            try
            {
                _tipopessoaApp.Remove(_tipopessoaApp.GetById(id));
                return Json(404);
            }
            catch (Exception exp)
            {
                return Json(exp.Message);
            }
        }
    }
}

