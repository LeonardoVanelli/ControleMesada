using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class PaisController : Controller
    {
        private readonly IPaisAppService _paisApp;

        public PaisController(IPaisAppService paisApp)
        {
            _paisApp = paisApp;
        }

        // GET: Paiss
        public ActionResult Index()
        {
            var paisViewModel = Mapper.Map<IEnumerable<Pais>, IEnumerable<PaisViewModel>>(_paisApp.GetAll());
            return View(paisViewModel);
        }

        // GET: Paiss/Details/5
        public ActionResult Details(int id)
        {
            var pais = _paisApp.GetById(id);
            var paisViewModel = Mapper.Map<Pais, PaisViewModel>(pais);
            return View(paisViewModel);
        }

        // GET: Paiss/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paiss/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaisViewModel pais)
        {
            if (ModelState.IsValid)
            {
                var paisDomain = Mapper.Map<PaisViewModel, Pais>(pais);
                _paisApp.Add(paisDomain);

                return RedirectToAction("Index");
            }

            return View(pais);
        }

        // GET: Paiss/Edit/5
        public ActionResult Edit(int id)
        {
            var pais = _paisApp.GetById(id);
            var paisViewModel = Mapper.Map<Pais, PaisViewModel>(pais);

            return View(paisViewModel);
        }

        // POST: Paiss/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PaisViewModel pais)
        {
            if (ModelState.IsValid)
            {
                var paisDomain = Mapper.Map<PaisViewModel, Pais>(pais);
                _paisApp.Update(paisDomain);

                return RedirectToAction("Index");
            }

            return View(pais);
        }

        // GET: Paiss/Delete/5
        public ActionResult Delete(int id)
        {
            var pais = _paisApp.GetById(id);
            var paisViewModel = Mapper.Map<Pais, PaisViewModel>(pais);

            return View(paisViewModel);
        }

        // POST: Paiss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var pais = _paisApp.GetById(id);

            _paisApp.Remove(pais);

            return RedirectToAction("Index");
        }
    }
}

