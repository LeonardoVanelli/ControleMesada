using AutoMapper;
using PrismaWEB.Utils.Exception;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using ProjetoModeloDDD.MVC.ViewModels.Sistema;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IPessoaAppService _pessoaApp;
        private readonly ISCadastroAppService _cadastroApp;
        private readonly IPaisAppService _paisApp;
        private readonly IEstadoAppService _estadoApp;
        private readonly ICidadeAppService _cidadeApp;
        private readonly IBairroAppService _bairroApp;
        private readonly ILogradouroAppService _logradouroApp;


        public PessoasController(IPessoaAppService pessoaApp,
                                 ISCadastroAppService cadastroApp,
                                 IPaisAppService paisApp,
                                 IEstadoAppService estadoApp,
                                 ICidadeAppService cidadeApp,
                                 IBairroAppService bairroApp,
                                 ILogradouroAppService logradouroApp)
        {
            _pessoaApp = pessoaApp;
            _cadastroApp = cadastroApp;
            _paisApp = paisApp;
            _estadoApp = estadoApp;
            _cidadeApp = cidadeApp;
            _bairroApp = bairroApp;
            _logradouroApp = logradouroApp;
        }

        // GET: Pessoas
        public ActionResult Index()
        {
            var pessoaViewModel = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewModel>>(_pessoaApp.GetAll());
            return View(pessoaViewModel);
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int id)
        {
            var pessoa = _pessoaApp.GetById(id);
            var pessoaViewModel = Mapper.Map<Pessoa, PessoaViewModel>(pessoa);
            return View(pessoaViewModel);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {            
            ViewBag.Pais_Id = new SelectList(_paisApp.GetAll(), "Id", "Nome");
            ViewBag.Estado_Id = new SelectList(_estadoApp.GetAll(), "Id", "Nome");
            ViewBag.Cidade_Id = new SelectList(_cidadeApp.GetAll(), "Id", "Nome");
            ViewBag.Bairro_Id = new SelectList(_bairroApp.GetAll(), "Id", "Nome");
            ViewBag.Logradouro_Id = new SelectList(_logradouroApp.GetAll(), "Id", "Nome");

            return View();
        }

        // POST: Pessoas/Create
        [HttpPost]
        public ActionResult Create(SPessoaCadastroViewModel pessoaCadastro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cadastroD = pessoaCadastro.MontaCadastro();
                    var pessoaD = pessoaCadastro.MontaPessoa();

                    _pessoaApp.AddPesoaComCadastro(pessoaD, cadastroD);
                    return RedirectToAction("Index");
                }

            }
            catch (ListEntidadeException exp)
            {
                foreach (var item in exp.Exceptions)
                {
                    ModelState.AddModelError(item.NomeCampo, item.Message);
                }                    
            }
            catch (EntidadeException exp)
            {
                ModelState.AddModelError(exp.NomeCampo, exp.Message);
            }

            ViewBag.Pais_Id = new SelectList(_paisApp.GetAll(), "Id", "Nome", pessoaCadastro.Pais_Id);
            ViewBag.Estado_Id = new SelectList(_estadoApp.GetAll(), "Id", "Nome", pessoaCadastro.Estado_Id);
            ViewBag.Cidade_Id = new SelectList(_cidadeApp.GetAll(), "Id", "Nome", pessoaCadastro.Cidade_Id);
            ViewBag.Bairro_Id = new SelectList(_bairroApp.GetAll(), "Id", "Nome", pessoaCadastro.Bairro_Id);
            ViewBag.Logradouro_Id = new SelectList(_logradouroApp.GetAll(), "Id", "Nome", pessoaCadastro.Logradouro_Id);
            return View(pessoaCadastro);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Pais_Id = new SelectList(_paisApp.GetAll(), "Id", "Nome");
            ViewBag.Estado_Id = new SelectList(_estadoApp.GetAll(), "Id", "Nome");
            ViewBag.Cidade_Id = new SelectList(_cidadeApp.GetAll(), "Id", "Nome");
            ViewBag.Bairro_Id = new SelectList(_bairroApp.GetAll(), "Id", "Nome");
            ViewBag.Logradouro_Id = new SelectList(_logradouroApp.GetAll(), "Id", "Nome");

            var pessoa = _pessoaApp.GetById(id);
            var pessoaCadastroViewModel = Mapper.Map<Pessoa, SPessoaCadastroViewModel>(pessoa);

            var cadastro = _cadastroApp.BuscaCadastroPorPessoa(id);

            if (cadastro != null)
            {
                pessoaCadastroViewModel.Login = cadastro.Login;
                pessoaCadastroViewModel.Senha = "********";
                pessoaCadastroViewModel.ValidaSenha = "********";
            }

            return View(pessoaCadastroViewModel);
        }

        // POST: Pessoas/Edit/5
        [HttpPost]
        public ActionResult Edit(SPessoaCadastroViewModel pessoaCadastro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pessoaD = pessoaCadastro.MontaPessoa();
                    var cadastroD = pessoaCadastro.MontaCadastro();

                    _pessoaApp.Update(pessoaD);                    
                    if (cadastroD != null)
                    {
                        if (cadastroD.Senha == "********")
                            cadastroD.Senha = null;

                        cadastroD.Pessoa_Id = pessoaD.Id;
                        _cadastroApp.Update(cadastroD);
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (ListEntidadeException exps)
            {
                foreach (var exp in exps.Exceptions)
                {
                    ModelState.AddModelError(exp.NomeCampo, exp.Message);
                }
            }
            catch (EntidadeException exp)
            {
                ModelState.AddModelError(exp.NomeCampo, exp.Message);
            }
            catch (Exception exp)
            {
                if (exp.InnerException != null)
                    ModelState.AddModelError(string.Empty, exp.InnerException.InnerException.Message);

            }
            ViewBag.Pais_Id = new SelectList(_paisApp.GetAll(), "Id", "Nome", pessoaCadastro.Pais_Id);
            ViewBag.Estado_Id = new SelectList(_estadoApp.GetAll(), "Id", "Nome", pessoaCadastro.Estado_Id);
            ViewBag.Cidade_Id = new SelectList(_cidadeApp.GetAll(), "Id", "Nome", pessoaCadastro.Cidade_Id);
            ViewBag.Bairro_Id = new SelectList(_bairroApp.GetAll(), "Id", "Nome", pessoaCadastro.Bairro_Id);
            ViewBag.Logradouro_Id = new SelectList(_logradouroApp.GetAll(), "Id", "Nome", pessoaCadastro.Logradouro_Id);
            return View(pessoaCadastro);
        }

        public ActionResult Desativar(int id)
        {
            _pessoaApp.DesativarPessoa(id);
            return RedirectToAction("Index");
        }

        public ActionResult Ativar(int id)
        {
            _pessoaApp.AtivarPessoa(id);
            return RedirectToAction("Index");
        }

        // GET: Pessoas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            try
            {
                _pessoaApp.Remove(_pessoaApp.GetById(id));
                return Json(404);
            }
            catch (Exception exp)
            {
                return Json(exp.InnerException.InnerException.Message);
            }            
        }
    }
}
