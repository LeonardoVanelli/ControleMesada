using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class EstadosController : Controller
    {
        private readonly IEstadoAppService _estadoApp;

        public EstadosController(IEstadoAppService estadoApp)
        {
            _estadoApp = estadoApp;
        }

        // GET: Estados
        public ActionResult Index()
        {
            var estadoViewModel = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_estadoApp.GetAll());
            return View(estadoViewModel);
        }

        // GET: Estados/Details/5
        public ActionResult Details(int id)
        {
            var estado = _estadoApp.GetById(id);
            var estadoViewModel = Mapper.Map<Estado, EstadoViewModel>(estado);
            return View(estadoViewModel);
        }

        // GET: Estados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstadoViewModel estado)
        {
            if (ModelState.IsValid)
            {
                var estadoDomain = Mapper.Map<EstadoViewModel, Estado>(estado);
                _estadoApp.Add(estadoDomain);

                return RedirectToAction("Index");
            }

            return View(estado);
        }

        // GET: Estados/Edit/5
        public ActionResult Edit(int id)
        {
            var estado = _estadoApp.GetById(id);
            var estadoViewModel = Mapper.Map<Estado, EstadoViewModel>(estado);

            return View(estadoViewModel);
        }

        // POST: Estados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EstadoViewModel estado)
        {
            if (ModelState.IsValid)
            {
                var estadoDomain = Mapper.Map<EstadoViewModel, Estado>(estado);
                _estadoApp.Update(estadoDomain);

                return RedirectToAction("Index");
            }

            return View(estado);
        }

        // GET: Estados/Delete/5
        public ActionResult Delete(int id)
        {
            var estado = _estadoApp.GetById(id);
            var estadoViewModel = Mapper.Map<Estado, EstadoViewModel>(estado);

            return View(estadoViewModel);
        }

        // POST: Estados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var estado = _estadoApp.GetById(id);

            _estadoApp.Remove(estado);

            return RedirectToAction("Index");
        }
    }
}

