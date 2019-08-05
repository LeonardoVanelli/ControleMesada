using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class PresidentesController : Controller
    {
        private readonly IPresidenteAppService _presidenteApp;

        public PresidentesController(IPresidenteAppService presidenteApp)
        {
            _presidenteApp = presidenteApp;
        }

        // GET: Presidentes
        public ActionResult Index()
        {
            var presidenteViewModel = Mapper.Map<IEnumerable<Presidente>, IEnumerable<PresidenteViewModel>>(_presidenteApp.GetAll());
            return View(presidenteViewModel);
        }

        // GET: Presidentes/Details/5
        public ActionResult Details(int id)
        {
            var presidente = _presidenteApp.GetById(id);
            var presidenteViewModel = Mapper.Map<Presidente, PresidenteViewModel>(presidente);
            return View(presidenteViewModel);
        }

        // GET: Presidentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Presidentes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PresidenteViewModel presidente)
        {
            if (ModelState.IsValid)
            {
                var presidenteDomain = Mapper.Map<PresidenteViewModel, Presidente>(presidente);
                _presidenteApp.Add(presidenteDomain);

                return RedirectToAction("Index");
            }

            return View(presidente);
        }

        // GET: Presidentes/Edit/5
        public ActionResult Edit(int id)
        {
            var presidente = _presidenteApp.GetById(id);
            var presidenteViewModel = Mapper.Map<Presidente, PresidenteViewModel>(presidente);

            return View(presidenteViewModel);
        }

        // POST: Presidentes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PresidenteViewModel presidente)
        {
            if (ModelState.IsValid)
            {
                var presidenteDomain = Mapper.Map<PresidenteViewModel, Presidente>(presidente);
                _presidenteApp.Update(presidenteDomain);

                return RedirectToAction("Index");
            }

            return View(presidente);
        }

        // GET: Presidentes/Delete/5
        public ActionResult Delete(int id)
        {
            var presidente = _presidenteApp.GetById(id);
            var presidenteViewModel = Mapper.Map<Presidente, PresidenteViewModel>(presidente);

            return View(presidenteViewModel);
        }

        // POST: Presidentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var presidente = _presidenteApp.GetById(id);

            _presidenteApp.Remove(presidente);

            return RedirectToAction("Index");
        }
    }
}

