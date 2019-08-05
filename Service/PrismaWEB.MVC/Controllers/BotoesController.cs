using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.Helpers.Armazenamento;
using ProjetoModeloDDD.MVC.ViewModels;
using ProjetoModeloDDD.MVC.ViewModels.Sistema;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class BotoesController : Controller
    {
        private readonly ISPapeisAcoesAppService _PapeisAcoesApp;

        public BotoesController(ISPapeisAcoesAppService PapeisAcoesApp)
        {
            _PapeisAcoesApp = PapeisAcoesApp;
        }

        // GET: Botoes
        public ActionResult BotaoCreate(string NomeController)
        {
            var usuario = ArmazemSession.Buscar("usuarioLogado") as SCadastroUsuarioLogadoViewModel;
            var papeisVM = usuario.Papeis;

            var papeis = Mapper.Map<IEnumerable<SPapelViewModel>, IList<SPapel>>(papeisVM);

            ViewBag.NomeController = NomeController;
            ViewBag.Visivel = _PapeisAcoesApp.PapeisTemAcessoAcao(papeis, NomeController);            
            return View();
        }
    }
}