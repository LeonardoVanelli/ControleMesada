using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using ProjetoModeloDDD.MVC.ViewModels.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IPessoaAppService _pessoaApp;
        private readonly ISCadastroAppService _cadastroApp;

        public UsuariosController(IPessoaAppService pessoaApp, ISCadastroAppService cadastroApp)
        {
            _pessoaApp = pessoaApp;
            _cadastroApp = cadastroApp;
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarioViewModel = Mapper.Engine.Map<IEnumerable<SUsuarioViewModel>>(_pessoaApp.BuscaPessoaComCadastro());
            var cadastroViewModel = Mapper.Engine.Map<IEnumerable<SCadastroViewModel>>(_cadastroApp.GetAll());

            foreach (var usuario in usuarioViewModel)
            {
                foreach (var cadastro in cadastroViewModel)
                {
                    if (usuario.Id == cadastro.Pessoa_Id)
                    {
                        usuario.Login = cadastro.Login;
                        usuario.Senha = cadastro.Senha;
                    }
                }
            }

            return View(usuarioViewModel);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            var usuarioViewModel = Mapper.Engine.Map<SUsuarioViewModel>(_pessoaApp.GetById(id));
            var cadastroViewModel = Mapper.Engine.Map<SCadastroViewModel>(_cadastroApp.BuscaCadastroPorPessoa(id));

            usuarioViewModel.Login = cadastroViewModel.Login;
            usuarioViewModel.Senha = cadastroViewModel.Senha;

            return View(usuarioViewModel);
        }

        // GET: Usuarios/Create
        public RedirectResult Create()
        {
            return RedirectPermanent("~/Pessoas/Create");
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            var usuarioViewModel = Mapper.Engine.Map<SUsuarioViewModel>(_pessoaApp.GetById(id));
            var cadastroViewModel = Mapper.Engine.Map<SCadastroViewModel>(_cadastroApp.BuscaCadastroPorPessoa(id));

            if (cadastroViewModel != null)
            {
                usuarioViewModel.Login = cadastroViewModel.Login;
                usuarioViewModel.Senha = cadastroViewModel.Senha;
            }            
            return View(usuarioViewModel);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(SUsuarioViewModel usuarioViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception();
                }

                var pessoaDomain = Mapper.Map<SUsuarioViewModel, Pessoa>(usuarioViewModel);
                var pessoa = _pessoaApp.GetById(usuarioViewModel.Id);

                pessoa.Nome = usuarioViewModel.Nome;
                pessoa.Email = usuarioViewModel.Email;                

                var cadastro = _cadastroApp.BuscaCadastroPorPessoa(usuarioViewModel.Id);                

                if (usuarioViewModel.Senha != "*******")
                {
                    if (!usuarioViewModel.SenhasValidas())
                    {
                        ModelState.AddModelError("ValidaSenha", "Senhas não são iguais");
                        throw new Exception();
                    }

                    cadastro.Login = usuarioViewModel.Login;
                    cadastro.Senha = usuarioViewModel.Senha;
                    _cadastroApp.Update(cadastro);
                }
                else
                {
                    if (usuarioViewModel.Login != cadastro.Login)
                    {
                        cadastro.Login = usuarioViewModel.Login;
                        _cadastroApp.Update(cadastro);
                    }
                }
                _pessoaApp.Update(pessoa);


                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(usuarioViewModel);
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
