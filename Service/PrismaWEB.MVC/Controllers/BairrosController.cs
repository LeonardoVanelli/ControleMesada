using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class BairrosController : Controller
    {
        private readonly IBairroAppService _bairroApp;

        public BairrosController(IBairroAppService bairroApp)
        {
            _bairroApp = bairroApp;
        }

        // GET: Bairros
        public ActionResult Index()
        {
            var bairroViewModel = Mapper.Map<IEnumerable<Bairro>, IEnumerable<BairroViewModel>>(_bairroApp.GetAll());
            return View(bairroViewModel);
        }

        // GET: Bairros/Details/5
        public ActionResult Details(int id)
        {
            var bairro = _bairroApp.GetById(id);
            var bairroViewModel = Mapper.Map<Bairro, BairroViewModel>(bairro);
            return View(bairroViewModel);
        }

        // GET: Bairros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bairros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BairroViewModel bairro)
        {
            if (ModelState.IsValid)
            {
                var bairroDomain = Mapper.Map<BairroViewModel, Bairro>(bairro);
                _bairroApp.Add(bairroDomain);

                return RedirectToAction("Index");
            }

            return View(bairro);
        }

        // GET: Bairros/Edit/5
        public ActionResult Edit(int id)
        {
            var bairro = _bairroApp.GetById(id);
            var bairroViewModel = Mapper.Map<Bairro, BairroViewModel>(bairro);

            return View(bairroViewModel);
        }

        // POST: Bairros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BairroViewModel bairro)
        {
            if (ModelState.IsValid)
            {
                var bairroDomain = Mapper.Map<BairroViewModel, Bairro>(bairro);
                _bairroApp.Update(bairroDomain);

                return RedirectToAction("Index");
            }

            return View(bairro);
        }

        // GET: Bairros/Delete/5
        public ActionResult Delete(int id)
        {
            var bairro = _bairroApp.GetById(id);
            var bairroViewModel = Mapper.Map<Bairro, BairroViewModel>(bairro);

            return View(bairroViewModel);
        }

        // POST: Bairros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var bairro = _bairroApp.GetById(id);

            _bairroApp.Remove(bairro);

            return RedirectToAction("Index");
        }
    }
}

