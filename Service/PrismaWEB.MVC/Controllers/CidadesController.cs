using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class CidadesController : Controller
    {
        private readonly ICidadeAppService _cidadeApp;

        public CidadesController(ICidadeAppService cidadeApp)
        {
            _cidadeApp = cidadeApp;
        }

        // GET: Cidades
        public ActionResult Index()
        {
            var cidadeViewModel = Mapper.Map<IEnumerable<Cidade>, IEnumerable<CidadeViewModel>>(_cidadeApp.GetAll());
            return View(cidadeViewModel);
        }

        // GET: Cidades/Details/5
        public ActionResult Details(int id)
        {
            var cidade = _cidadeApp.GetById(id);
            var cidadeViewModel = Mapper.Map<Cidade, CidadeViewModel>(cidade);
            return View(cidadeViewModel);
        }

        // GET: Cidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cidades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CidadeViewModel cidade)
        {
            if (ModelState.IsValid)
            {
                var cidadeDomain = Mapper.Map<CidadeViewModel, Cidade>(cidade);
                _cidadeApp.Add(cidadeDomain);

                return RedirectToAction("Index");
            }

            return View(cidade);
        }

        // GET: Cidades/Edit/5
        public ActionResult Edit(int id)
        {
            var cidade = _cidadeApp.GetById(id);
            var cidadeViewModel = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            return View(cidadeViewModel);
        }

        // POST: Cidades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CidadeViewModel cidade)
        {
            if (ModelState.IsValid)
            {
                var cidadeDomain = Mapper.Map<CidadeViewModel, Cidade>(cidade);
                _cidadeApp.Update(cidadeDomain);

                return RedirectToAction("Index");
            }

            return View(cidade);
        }

        // GET: Cidades/Delete/5
        public ActionResult Delete(int id)
        {
            var cidade = _cidadeApp.GetById(id);
            var cidadeViewModel = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            return View(cidadeViewModel);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cidade = _cidadeApp.GetById(id);

            _cidadeApp.Remove(cidade);

            return RedirectToAction("Index");
        }
    }
}

