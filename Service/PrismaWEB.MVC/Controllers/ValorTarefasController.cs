using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ValorTarefasController : Controller
    {
        private readonly IValorTarefaAppService _valortarefaApp;
        private readonly ITarefaAppService _tarefaApp;


        public ValorTarefasController(IValorTarefaAppService valortarefaApp, ITarefaAppService tarefaApp)
        {
            _valortarefaApp = valortarefaApp;
            _tarefaApp = tarefaApp;
        }

        // GET: ValorTarefas
        public ActionResult Index()

        {
            var valortarefaViewModel = Mapper.Map<IEnumerable<ValorTarefa>, IEnumerable<ValorTarefaViewModel>>(_valortarefaApp.GetAll());
            return View(valortarefaViewModel);
        }

        // GET: ValorTarefas/Details/5
        public ActionResult Details(int id)
        {
            var valortarefa = _valortarefaApp.GetById(id);
            var valortarefaViewModel = Mapper.Map<ValorTarefa, ValorTarefaViewModel>(valortarefa);
            return View(valortarefaViewModel);
        }

        // GET: ValorTarefas/Create
        public ActionResult Create()
        {
            ViewBag.Tarefa_Id = new SelectList(_tarefaApp.GetAll(), "Id", "Nome");
            return View();
        }

        // POST: ValorTarefas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ValorTarefaViewModel valortarefa)
        {
            if (ModelState.IsValid)
            {
                var valortarefaDomain = Mapper.Map<ValorTarefaViewModel, ValorTarefa>(valortarefa);
                _valortarefaApp.Add(valortarefaDomain);

                return RedirectToAction("Index");
            }

            ViewBag.Tarefa_Id = new SelectList(_tarefaApp.GetAll(), "Id", "Nome", valortarefa.Tarefa_Id);
            return View(valortarefa);
        }

        // GET: ValorTarefas/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Tarefa_Id = new SelectList(_tarefaApp.GetAll(), "Id", "Nome");

            var valortarefa = _valortarefaApp.GetById(id);
            var valortarefaViewModel = Mapper.Map<ValorTarefa, ValorTarefaViewModel>(valortarefa);

            return View(valortarefaViewModel);
        }

        // POST: ValorTarefas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ValorTarefaViewModel valortarefa)
        {
            if (ModelState.IsValid)
            {
                var valortarefaDomain = Mapper.Map<ValorTarefaViewModel, ValorTarefa>(valortarefa);
                _valortarefaApp.Update(valortarefaDomain);

                return RedirectToAction("Index");
            }

            ViewBag.Tarefa_Id = new SelectList(_tarefaApp.GetAll(), "Id", "Nome", valortarefa.Tarefa_Id);
            return View(valortarefa);
        }

        // GET: ValorTarefas/Delete/5
        public ActionResult Delete(int id)
        {
            var valortarefa = _valortarefaApp.GetById(id);
            var valortarefaViewModel = Mapper.Map<ValorTarefa, ValorTarefaViewModel>(valortarefa);

            return View(valortarefaViewModel);
        }

        // POST: ValorTarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var valortarefa = _valortarefaApp.GetById(id);

            _valortarefaApp.Remove(valortarefa);

            return RedirectToAction("Index");
        }
    }
}

