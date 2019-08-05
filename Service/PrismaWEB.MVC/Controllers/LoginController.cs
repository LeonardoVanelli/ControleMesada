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

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISCadastroAppService _cadastroApp;
        private readonly ISPapelAppService _PapelApp;

        public LoginController(ISCadastroAppService cadastroApp, ISPapelAppService PapelApp)
        {
            _cadastroApp = cadastroApp;
            _PapelApp = PapelApp;
        }

        // GET: Login
        public ActionResult Index(string actn, string ctrl)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SCadastroUsuarioLogadoViewModel cadastro, string actn, string ctrl)
        {
            var sCadastro = _cadastroApp.BuscaUsuarioLoginSenha(cadastro.Login, cadastro.Senha);
            if (sCadastro != null)
            {                
                if (Session["usuarioLogado"] == null)
                {
                    var cadastroUsuarioLogado = Mapper.Map<SCadastro, SCadastroUsuarioLogadoViewModel>(sCadastro);
                    cadastroUsuarioLogado.Papeis = buscaPapeis(sCadastro.Pessoa_Id);
                    Session.Timeout = 10;
                    Session.Add("usuarioLogado", cadastroUsuarioLogado);
                }
                if (sCadastro.AlterarSenha == true)
                {
                    return RedirectToAction("AlterarSenha", "SCadastros");
                }
                if (actn != null && ctrl != null)
                    return RedirectToAction(actn, ctrl);
                return RedirectToAction("Index", "Home");
            }            
            ModelState.AddModelError(string.Empty, "Login ou Senha inválido");
            return View(cadastro);
        }

        public ActionResult Logout()
        {
            if (Session["usuarioLogado"] != null)
                Session["usuarioLogado"] = null;
            return RedirectToAction("Index", "Home");
        }

        #region Private
        private IList<SPapelViewModel> buscaPapeis(int IdUsuario)
        {
            return Mapper.Map<IEnumerable<SPapel>, IList<SPapelViewModel>>(_PapelApp.BuscaTodosPorPessoa(IdUsuario));
        }
        #endregion
    }
}