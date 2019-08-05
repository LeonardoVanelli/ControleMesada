using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class TarefasController : Controller
    {
        private readonly ITarefaAppService _tarefaApp;

        public TarefasController(ITarefaAppService tarefaApp)
        {
            _tarefaApp = tarefaApp;
        }

        // GET: Tarefas
        public ActionResult Index()
        {
            var tarefaViewModel = Mapper.Map<IEnumerable<Tarefa>, IEnumerable<TarefaViewModel>>(_tarefaApp.GetAll());
            return View(tarefaViewModel);
        }

        // GET: Tarefas/Details/5
        public ActionResult Details(int id)
        {
            var tarefa = _tarefaApp.GetById(id);
            var tarefaViewModel = Mapper.Map<Tarefa, TarefaViewModel>(tarefa);
            return View(tarefaViewModel);
        }

        // GET: Tarefas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tarefas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TarefaViewModel tarefa)
        {
            if (ModelState.IsValid)
            {
                var tarefaDomain = Mapper.Map<TarefaViewModel, Tarefa>(tarefa);
                _tarefaApp.Add(tarefaDomain);

                return RedirectToAction("Index");
            }

            return View(tarefa);
        }

        // GET: Tarefas/Edit/5
        public ActionResult Edit(int id)
        {
            var tarefa = _tarefaApp.GetById(id);
            var tarefaViewModel = Mapper.Map<Tarefa, TarefaViewModel>(tarefa);

            return View(tarefaViewModel);
        }

        // POST: Tarefas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TarefaViewModel tarefa)
        {
            if (ModelState.IsValid)
            {
                var tarefaDomain = Mapper.Map<TarefaViewModel, Tarefa>(tarefa);
                _tarefaApp.Update(tarefaDomain);

                return RedirectToAction("Index");
            }

            return View(tarefa);
        }

        // GET: Tarefas/Delete/5
        public ActionResult Delete(int id)
        {
            var tarefa = _tarefaApp.GetById(id);
            var tarefaViewModel = Mapper.Map<Tarefa, TarefaViewModel>(tarefa);

            return View(tarefaViewModel);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var tarefa = _tarefaApp.GetById(id);

            _tarefaApp.Remove(tarefa);

            return RedirectToAction("Index");
        }
    }
}

