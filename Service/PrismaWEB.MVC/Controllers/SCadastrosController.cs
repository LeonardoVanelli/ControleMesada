using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.Atributos;
using ProjetoModeloDDD.MVC.ViewModels;
using ProjetoModeloDDD.MVC.ViewModels.Sistema;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class SCadastrosController : Controller
    {
        private readonly ISCadastroAppService _scadastroApp;

        public SCadastrosController(ISCadastroAppService scadastroApp)
        {
            _scadastroApp = scadastroApp;
        }

        // GET: SCadastros/Create
        public ActionResult Create(int idPessoa)
        {
            TempData["cliente"] = idPessoa;
            var scadastro = _scadastroApp.BuscaCadastroPorPessoa(idPessoa);
            var scadastroViewModel = Mapper.Map<SCadastro, SCadastroViewModel>(scadastro);

            return PartialView(scadastroViewModel);
        }

        [HttpGet]
        public ActionResult AlterarSenha()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarSenha(SCadastroViewModel cadastrovm)
        {
            if (Session["usuarioLogado"] != null)
            {
                cadastrovm.Pessoa_Id = (Session["usuarioLogado"] as SCadastroUsuarioLogadoViewModel).Pessoa_Id;
                cadastrovm.Login = (Session["usuarioLogado"] as SCadastroUsuarioLogadoViewModel).Login;
            }

            try
            {
                //ModelState.Clear();
                if (!_scadastroApp.SenhaIgualAnterior(cadastrovm.Pessoa_Id, cadastrovm.SenhaAnterior))
                    ModelState.AddModelError("SenhaAnterior", "Senha Inválido");
                if (!cadastrovm.SenhasValidas())
                    ModelState.AddModelError("ValidaSenha", "Senhas não são iguais");
                if (ModelState.IsValid)
                {
                    var cadastro = Mapper.Map<SCadastroViewModel, SCadastro>(cadastrovm);
                    cadastro.AlterarSenha = false;
                    _scadastroApp.Update(cadastro);
                    return RedirectToAction("Index", "Home");
                }
                else
                    return View(cadastrovm);
            }
            catch (Exception exp)
            {
                ModelState.AddModelError(string.Empty, exp.Message);
                return View(cadastrovm);
            }
        }

        public JsonResult AtualizaSenha(string Login, string Senha, string ConfirmaSenha)
        {
            if (Senha != ConfirmaSenha)
                return Json("SenhaNaoIguais", JsonRequestBehavior.AllowGet);

            if (Senha.Length <= 6)
                return Json("Senha deve ter no minimo 7 caracteres", JsonRequestBehavior.AllowGet);

            var cadastro = new SCadastro()
            {
                Pessoa_Id = Convert.ToInt32(TempData["cliente"]),
                Login = Login,
                Senha = Senha
            };

            _scadastroApp.Update(cadastro);
            return Json("Sucesso", JsonRequestBehavior.AllowGet);
        }
    }
}

