using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class SPessoasPapeisController : Controller
    {
        private readonly ISPessoasPapeisAppService _spessoaspapeisApp;
        private readonly ISPapelAppService _spapelApp;

        public SPessoasPapeisController(ISPessoasPapeisAppService spessoaspapeisApp, ISPapelAppService spapelApp)
        {
            _spessoaspapeisApp = spessoaspapeisApp;
            _spapelApp = spapelApp;
        }

        // GET: SPessoasPapeiss
        public ActionResult Index()
        {
            var spessoaspapeisViewModel = Mapper.Map<IEnumerable<SPessoasPapeis>, IEnumerable<SPessoasPapeisViewModel>>(_spessoaspapeisApp.GetAll());
            return View(spessoaspapeisViewModel);
        }

        // GET: SPessoasPapeiss/Details/5
        public ActionResult Details(int id)
        {
            var spessoaspapeis = _spessoaspapeisApp.GetById(id);
            var spessoaspapeisViewModel = Mapper.Map<SPessoasPapeis, SPessoasPapeisViewModel>(spessoaspapeis);
            return View(spessoaspapeisViewModel);
        }

        // GET: SPessoasPapeiss/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SPessoasPapeiss/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SPessoasPapeisViewModel spessoaspapeis)
        {
            if (ModelState.IsValid)
            {
                var spessoaspapeisDomain = Mapper.Map<SPessoasPapeisViewModel, SPessoasPapeis>(spessoaspapeis);
                _spessoaspapeisApp.Add(spessoaspapeisDomain);

                return RedirectToAction("Index");
            }

            return View(spessoaspapeis);
        }

        public PartialViewResult IndexUsuario(int idUsuario)
        {
            var pessoaspapeisViewModel = Mapper.Map<IEnumerable<SPessoasPapeis>, IEnumerable<SPessoasPapeisViewModel>>(_spessoaspapeisApp.BuscarPorPessoa(idUsuario));
            if (TempData.ContainsKey("idPessoa"))
                TempData["idPessoa"] = idUsuario;
            else
                TempData.Add("idPessoa", idUsuario);

            ViewBag.Papel_Id = new SelectList(_spapelApp.BuscaNaoCadastradoPorPessoa(idUsuario), "Id", "Nome");

            return PartialView(pessoaspapeisViewModel);
        }

        // GET: SPessoasPapeiss/Edit/5
        public ActionResult Edit(int id)
        {
            var spessoaspapeis = _spessoaspapeisApp.GetById(id);
            var spessoaspapeisViewModel = Mapper.Map<SPessoasPapeis, SPessoasPapeisViewModel>(spessoaspapeis);

            return View(spessoaspapeisViewModel);
        }

        // POST: SPessoasPapeiss/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SPessoasPapeisViewModel spessoaspapeis)
        {
            if (ModelState.IsValid)
            {
                var spessoaspapeisDomain = Mapper.Map<SPessoasPapeisViewModel, SPessoasPapeis>(spessoaspapeis);
                _spessoaspapeisApp.Update(spessoaspapeisDomain);

                return RedirectToAction("Index");
            }

            return View(spessoaspapeis);
        }

        // GET: SPessoasPapeiss/Delete/5
        public ActionResult Delete(int id)
        {
            var spessoaspapeis = _spessoaspapeisApp.GetById(id);
            var spessoaspapeisViewModel = Mapper.Map<SPessoasPapeis, SPessoasPapeisViewModel>(spessoaspapeis);

            return View(spessoaspapeisViewModel);
        }

        // POST: SPessoasPapeiss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var spessoaspapeis = _spessoaspapeisApp.GetById(id);

            _spessoaspapeisApp.Remove(spessoaspapeis);

            return RedirectToAction("Index");
        }

        public JsonResult AlteraItem(int idItem, bool conceder)
        {
            var pessoaPapel = _spessoaspapeisApp.GetById(idItem);
            pessoaPapel.Conceder = conceder;
            _spessoaspapeisApp.Update(pessoaPapel);

            return Json("");
        }

        public JsonResult AdicionarItem(int idPapel, bool conceder)
        {
            var pessoaPapel = new SPessoasPapeis
            {
                Papel_Id = idPapel,
                Conceder = conceder,
                Pessoa_Id = (int)TempData["idPessoa"]
            };

            _spessoaspapeisApp.Add(pessoaPapel);
            TempData["idPessoa"] = TempData["idPessoa"];
            return Json(pessoaPapel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoverItem(int idItem)
        {
            var pessoaPapel = _spessoaspapeisApp.GetById(idItem);
            var papel = pessoaPapel.Papel;
            _spessoaspapeisApp.Remove(pessoaPapel);

            return Json(papel, JsonRequestBehavior.AllowGet);
        }
    }
}

