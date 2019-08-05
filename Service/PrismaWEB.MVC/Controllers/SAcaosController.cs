using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class SAcaosController : Controller
    {
        private readonly ISAcaoAppService _sacaoApp;

        public SAcaosController(ISAcaoAppService sacaoApp)
        {
            _sacaoApp = sacaoApp;
        }

        // GET: SAcaos
        public ActionResult Index()
        {
            var sacaoViewModel = Mapper.Map<IEnumerable<SAcao>, IEnumerable<SAcaoViewModel>>(_sacaoApp.GetAll());
            return View(sacaoViewModel);
        }

        // GET: SAcaos/Details/5
        public ActionResult Details(int id)
        {
            var sacao = _sacaoApp.GetById(id);
            var sacaoViewModel = Mapper.Map<SAcao, SAcaoViewModel>(sacao);
            return View(sacaoViewModel);
        }

        // GET: SAcaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SAcaos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SAcaoViewModel sacao)
        {
            if (ModelState.IsValid)
            {
                var sacaoDomain = Mapper.Map<SAcaoViewModel, SAcao>(sacao);
                _sacaoApp.Add(sacaoDomain);

                return RedirectToAction("Index");
            }

            return View(sacao);
        }

        // GET: SAcaos/Edit/5
        public ActionResult Edit(int id)
        {
            var sacao = _sacaoApp.GetById(id);
            var sacaoViewModel = Mapper.Map<SAcao, SAcaoViewModel>(sacao);

            return View(sacaoViewModel);
        }

        // POST: SAcaos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SAcaoViewModel sacao)
        {
            if (ModelState.IsValid)
            {
                var sacaoDomain = Mapper.Map<SAcaoViewModel, SAcao>(sacao);
                _sacaoApp.Update(sacaoDomain);

                return RedirectToAction("Index");
            }

            return View(sacao);
        }

        // GET: SAcaos/Delete/5
        public ActionResult Delete(int id)
        {
            var sacao = _sacaoApp.GetById(id);
            var sacaoViewModel = Mapper.Map<SAcao, SAcaoViewModel>(sacao);

            return View(sacaoViewModel);
        }

        // POST: SAcaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var sacao = _sacaoApp.GetById(id);

            _sacaoApp.Remove(sacao);

            return RedirectToAction("Index");
        }
    }
}

