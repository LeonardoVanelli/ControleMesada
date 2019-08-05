using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using PrismaWEB.Utils.Exception;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class AtividadesController : Controller
    {
        private readonly IAtividadeAppService _atividadeApp;
        private readonly ITarefaAppService _tarefaApp;
        private readonly IPessoaAppService _pessoaApp;

        public AtividadesController(IAtividadeAppService atividadeApp, ITarefaAppService tarefaApp, IPessoaAppService pessoaApp)
        {
            _atividadeApp = atividadeApp;
            _tarefaApp = tarefaApp;
            _pessoaApp = pessoaApp;
        }

        // GET: Atividades
        public ActionResult Index()
        {
            var atividadeViewModel = Mapper.Map<IEnumerable<Atividade>, IEnumerable<AtividadeViewModel>>(_atividadeApp.GetAll());
            return View(atividadeViewModel);
        }

        // GET: Atividades/Details/5
        public ActionResult Details(int id)
        {
            var atividade = _atividadeApp.GetById(id);
            var atividadeViewModel = Mapper.Map<Atividade, AtividadeViewModel>(atividade);
            return View(atividadeViewModel);
        }

        // GET: Atividades/Create
        public ActionResult Create()
        {
            ViewBag.Pessoa_Id = new SelectList(_pessoaApp.GetAll(), "Id", "Nome");
            ViewBag.Tarefa_Id = new SelectList(_tarefaApp.GetAll(), "Id", "Nome");
            return View();
        }

        // POST: Atividades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AtividadeViewModel atividade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var atividadeDomain = Mapper.Map<AtividadeViewModel, Atividade>(atividade);
                    _atividadeApp.Add(atividadeDomain);

                    return RedirectToAction("Index");
                }
            }
            catch (EntidadeException exp)
            {
                ModelState.AddModelError("", exp.Message);
            }


            ViewBag.Tarefa_Id = new SelectList(_tarefaApp.GetAll(), "Id", "Nome", atividade.Tarefa_Id);
            ViewBag.Pessoa_Id = new SelectList(_pessoaApp.GetAll(), "Id", "Nome", atividade.Pessoa_Id);
            return View(atividade);
        }

        // GET: Atividades/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Pessoa_Id = new SelectList(_pessoaApp.GetAll(), "Id", "Nome");
            ViewBag.Tarefa_Id = new SelectList(_tarefaApp.GetAll(), "Id", "Nome");

            var atividade = _atividadeApp.GetById(id);
            var atividadeViewModel = Mapper.Map<Atividade, AtividadeViewModel>(atividade);

            return View(atividadeViewModel);
        }

        // POST: Atividades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AtividadeViewModel atividade)
        {
            if (ModelState.IsValid)
            {
                var atividadeDomain = Mapper.Map<AtividadeViewModel, Atividade>(atividade);
                _atividadeApp.Update(atividadeDomain);

                return RedirectToAction("Index");
            }

            ViewBag.Tarefa_Id = new SelectList(_tarefaApp.GetAll(), "Id", "Nome", atividade.Tarefa_Id);
            ViewBag.Pessoa_Id = new SelectList(_pessoaApp.GetAll(), "Id", "Nome", atividade.Pessoa_Id);
            return View(atividade);
        }

        // GET: Atividades/Delete/5
        public ActionResult Delete(int id)
        {
            var atividade = _atividadeApp.GetById(id);
            var atividadeViewModel = Mapper.Map<Atividade, AtividadeViewModel>(atividade);

            return View(atividadeViewModel);
        }

        // POST: Atividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var atividade = _atividadeApp.GetById(id);

            _atividadeApp.Remove(atividade);

            return RedirectToAction("Index");
        }
    }
}

