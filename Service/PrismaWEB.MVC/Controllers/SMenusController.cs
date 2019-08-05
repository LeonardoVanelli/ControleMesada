using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using ProjetoModeloDDD.MVC.AutoMapper;
using ProjetoModeloDDD.Domain.Entities.Sistema;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class SMenusController : Controller
    {
        private readonly ISMenusAppService _smenusApp;

        public SMenusController(ISMenusAppService smenusApp)
        {
            _smenusApp = smenusApp;
        }

        // GET: SMenuss
        public ActionResult Index()
        {
            var smenusViewModel = Mapper.Map<IEnumerable<SMenus>, IEnumerable<SMenusViewModel>>(_smenusApp.GetAll());
            return View(smenusViewModel);
        }

        // GET: SMenuss/Details/5
        public ActionResult Details(int id)
        {
            var smenus = _smenusApp.GetById(id);
            var smenusViewModel = Mapper.Map<SMenus, SMenusViewModel>(smenus);
            return View(smenusViewModel);
        }

        // GET: SMenuss/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SMenuss/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SMenusViewModel smenus)
        {
            if (ModelState.IsValid)
            {
                var smenusDomain = Mapper.Map<SMenusViewModel, SMenus>(smenus);
                _smenusApp.Add(smenusDomain);

                return RedirectToAction("Index");
            }

            return View(smenus);
        }

        // GET: SMenuss/Edit/5
        public ActionResult Edit(int id)
        {
            var smenus = _smenusApp.GetById(id);
            var smenusViewModel = Mapper.Map<SMenus, SMenusViewModel>(smenus);

            return View(smenusViewModel);
        }

        // POST: SMenuss/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SMenusViewModel smenus)
        {
            if (ModelState.IsValid)
            {
                var smenusDomain = Mapper.Map<SMenusViewModel, SMenus>(smenus);
                _smenusApp.Update(smenusDomain);

                return RedirectToAction("Index");
            }

            return View(smenus);
        }

        // GET: SMenuss/Delete/5
        public ActionResult Delete(int id)
        {
            var smenus = _smenusApp.GetById(id);
            var smenusViewModel = Mapper.Map<SMenus, SMenusViewModel>(smenus);

            return View(smenusViewModel);
        }

        // POST: SMenuss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var smenus = _smenusApp.GetById(id);

            _smenusApp.Remove(smenus);

            return RedirectToAction("Index");
        }
    }
}

