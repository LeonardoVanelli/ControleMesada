using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class SPapeisController : Controller
    {
        private readonly ISPapelAppService _spapelApp;

        public SPapeisController(ISPapelAppService spapelApp)
        {
            _spapelApp = spapelApp;
        }

        // GET: SPapels
        public ActionResult Index()
        {
            var spapelViewModel = Mapper.Map<IEnumerable<SPapel>, IEnumerable<SPapelViewModel>>(_spapelApp.GetAll());
            return View(spapelViewModel);
        }

        // GET: SPapels/Details/5
        public ActionResult Details(int id)
        {
            var spapel = _spapelApp.GetById(id);
            var spapelViewModel = Mapper.Map<SPapel, SPapelViewModel>(spapel);
            return View(spapelViewModel);
        }

        // GET: SPapels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SPapels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SPapelViewModel spapel)
        {
            if (ModelState.IsValid)
            {
                var spapelDomain = Mapper.Map<SPapelViewModel, SPapel>(spapel);
                _spapelApp.Add(spapelDomain);

                return RedirectToAction("Index");
            }

            return View(spapel);
        }

        // GET: SPapels/Edit/5
        public ActionResult Edit(int id)
        {
            var spapel = _spapelApp.GetById(id);
            var spapelViewModel = Mapper.Map<SPapel, SPapelViewModel>(spapel);

            return View(spapelViewModel);
        }

        // POST: SPapels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SPapelViewModel spapel)
        {
            if (ModelState.IsValid)
            {
                var spapelDomain = Mapper.Map<SPapelViewModel, SPapel>(spapel);
                _spapelApp.Update(spapelDomain);

                return RedirectToAction("Index");
            }

            return View(spapel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            try
            {
                _spapelApp.Remove(_spapelApp.GetById(id));
                return Json(404);
            }
            catch (Exception exp)
            {
                return Json(exp.Message);
            }
        }
    }
}

