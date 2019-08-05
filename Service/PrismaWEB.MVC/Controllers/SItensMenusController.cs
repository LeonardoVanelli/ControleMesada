using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Entities.Sistema;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class SItensMenusController : Controller
    {
        private readonly ISItensMenuAppService _sItensMenuApp;
        private readonly ISMenusAppService _sMenuApp;
        private readonly ISPaginaAppService _sPaginaApp;

        public SItensMenusController(ISItensMenuAppService sitensmenuApp, ISMenusAppService smenuApp, ISPaginaAppService sPaginaApp)
        {
            _sItensMenuApp = sitensmenuApp;
            _sMenuApp = smenuApp;
            _sPaginaApp = sPaginaApp;
        }

        // GET: SItensMenus
        public ActionResult Index()
        {
            var sitensmenuViewModel = Mapper.Map<IEnumerable<SItensMenu>, IEnumerable<SItensMenuViewModel>>(_sItensMenuApp.GetAll());
            return View(sitensmenuViewModel);
        }

        // GET: SItensMenus/Details/5
        public ActionResult Details(int id)
        {
            var sitensmenu = _sItensMenuApp.GetById(id);
            var sitensmenuViewModel = Mapper.Map<SItensMenu, SItensMenuViewModel>(sitensmenu);
            return View(sitensmenuViewModel);
        }

        // GET: SItensMenus/Create
        public ActionResult Create()
        {
            ViewBag.ItemPai_Id = new SelectList(_sItensMenuApp.GetAll(), "Id", "Nome");
            ViewBag.Menu_Id = new SelectList(_sMenuApp.GetAll(),"Id", "Nome");
            ViewBag.Pagina_Id = new SelectList(_sPaginaApp.GetAll(),"Id", "Nome");
            return View();
        }

        // POST: SItensMenus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SItensMenuViewModel itensMenu)
        {
            if (ModelState.IsValid)
            {
                var sitensmenuDomain = Mapper.Map<SItensMenuViewModel, SItensMenu>(itensMenu);
                _sItensMenuApp.Add(sitensmenuDomain);

                return RedirectToAction("Index");
            }

            ViewBag.ItemPai_Id = new SelectList(_sItensMenuApp.GetAll(), "Id", "Nome");
            ViewBag.Menu_Id = new SelectList(_sMenuApp.GetAll(), "Id", "Nome");
            ViewBag.Pagina_Id = new SelectList(_sPaginaApp.GetAll(), "Id", "Nome");
            return View(itensMenu);
        }

        // GET: SItensMenus/Edit/5
        public ActionResult Edit(int id)
        {
            var sitensmenu = _sItensMenuApp.GetById(id);
            var sitensmenuViewModel = Mapper.Map<SItensMenu, SItensMenuViewModel>(sitensmenu);

            return View(sitensmenuViewModel);
        }

        // POST: SItensMenus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SItensMenuViewModel sitensmenu)
        {
            if (ModelState.IsValid)
            {
                var sitensmenuDomain = Mapper.Map<SItensMenuViewModel, SItensMenu>(sitensmenu);
                _sItensMenuApp.Update(sitensmenuDomain);

                return RedirectToAction("Index");
            }

            return View(sitensmenu);
        }

        // GET: SItensMenus/Delete/5
        public ActionResult Delete(int id)
        {
            var sitensmenu = _sItensMenuApp.GetById(id);
            var sitensmenuViewModel = Mapper.Map<SItensMenu, SItensMenuViewModel>(sitensmenu);

            return View(sitensmenuViewModel);
        }

        // POST: SItensMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var sitensmenu = _sItensMenuApp.GetById(id);

            _sItensMenuApp.Remove(sitensmenu);

            return RedirectToAction("Index");
        }
    }
}

