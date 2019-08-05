using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class SPaginasController : Controller
    {
        private readonly ISPaginaAppService _spaginaApp;

        public SPaginasController(ISPaginaAppService spaginaApp)
        {
            _spaginaApp = spaginaApp;
        }

        // GET: SPaginas
        public ActionResult Index()
        {
            var spaginaViewModel = Mapper.Map<IEnumerable<SPagina>, IEnumerable<SPaginaViewModel>>(_spaginaApp.GetAll());
            return View(spaginaViewModel);
        }

        // GET: SPaginas/Details/5
        public ActionResult Details(int id)
        {
            var spagina = _spaginaApp.GetById(id);
            var spaginaViewModel = Mapper.Map<SPagina, SPaginaViewModel>(spagina);
            return View(spaginaViewModel);
        }

        // GET: SPaginas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SPaginas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SPaginaViewModel spagina)
        {
            if (ModelState.IsValid)
            {
                var spaginaDomain = Mapper.Map<SPaginaViewModel, SPagina>(spagina);
                _spaginaApp.Add(spaginaDomain);

                return RedirectToAction("Index");
            }

            return View(spagina);
        }

        // GET: SPaginas/Edit/5
        public ActionResult Edit(int id)
        {
            var spagina = _spaginaApp.GetById(id);
            var spaginaViewModel = Mapper.Map<SPagina, SPaginaViewModel>(spagina);

            return View(spaginaViewModel);
        }

        // POST: SPaginas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SPaginaViewModel spagina)
        {
            if (ModelState.IsValid)
            {
                var spaginaDomain = Mapper.Map<SPaginaViewModel, SPagina>(spagina);
                _spaginaApp.Update(spaginaDomain);

                return RedirectToAction("Index");
            }

            return View(spagina);
        }

        // GET: SPaginas/Delete/5
        public ActionResult Delete(int id)
        {
            var spagina = _spaginaApp.GetById(id);
            var spaginaViewModel = Mapper.Map<SPagina, SPaginaViewModel>(spagina);

            return View(spaginaViewModel);
        }

        // POST: SPaginas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var spagina = _spaginaApp.GetById(id);

            _spaginaApp.Remove(spagina);

            return RedirectToAction("Index");
        }
    }
}

