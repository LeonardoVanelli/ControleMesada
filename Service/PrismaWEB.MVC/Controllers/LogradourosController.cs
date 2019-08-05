using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class LogradourosController : Controller
    {
        private readonly ILogradouroAppService _logradouroApp;

        public LogradourosController(ILogradouroAppService logradouroApp)
        {
            _logradouroApp = logradouroApp;
        }

        // GET: Logradouros
        public ActionResult Index()
        {
            var logradouroViewModel = Mapper.Map<IEnumerable<Logradouro>, IEnumerable<LogradouroViewModel>>(_logradouroApp.GetAll());
            return View(logradouroViewModel);
        }

        // GET: Logradouros/Details/5
        public ActionResult Details(int id)
        {
            var logradouro = _logradouroApp.GetById(id);
            var logradouroViewModel = Mapper.Map<Logradouro, LogradouroViewModel>(logradouro);
            return View(logradouroViewModel);
        }

        // GET: Logradouros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logradouros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LogradouroViewModel logradouro)
        {
            if (ModelState.IsValid)
            {
                var logradouroDomain = Mapper.Map<LogradouroViewModel, Logradouro>(logradouro);
                _logradouroApp.Add(logradouroDomain);

                return RedirectToAction("Index");
            }

            return View(logradouro);
        }

        // GET: Logradouros/Edit/5
        public ActionResult Edit(int id)
        {
            var logradouro = _logradouroApp.GetById(id);
            var logradouroViewModel = Mapper.Map<Logradouro, LogradouroViewModel>(logradouro);

            return View(logradouroViewModel);
        }

        // POST: Logradouros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LogradouroViewModel logradouro)
        {
            if (ModelState.IsValid)
            {
                var logradouroDomain = Mapper.Map<LogradouroViewModel, Logradouro>(logradouro);
                _logradouroApp.Update(logradouroDomain);

                return RedirectToAction("Index");
            }

            return View(logradouro);
        }

        // GET: Logradouros/Delete/5
        public ActionResult Delete(int id)
        {
            var logradouro = _logradouroApp.GetById(id);
            var logradouroViewModel = Mapper.Map<Logradouro, LogradouroViewModel>(logradouro);

            return View(logradouroViewModel);
        }

        // POST: Logradouros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var logradouro = _logradouroApp.GetById(id);

            _logradouroApp.Remove(logradouro);

            return RedirectToAction("Index");
        }
    }
}

