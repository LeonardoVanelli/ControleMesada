using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.Atributos;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ConfiguracoesController : Controller
    {
        private readonly ISPapelAppService _PapelApp;
        private readonly ISAcaoAppService _AcaoApp;
        private readonly ISPaginaAppService _PaginaApp;

        public ConfiguracoesController(ISPapelAppService PapelApp, ISAcaoAppService AcaoApp, ISPaginaAppService PaginaApp)
        {
            _PapelApp = PapelApp;
            _AcaoApp = AcaoApp;
            _PaginaApp = PaginaApp;
        }

        // GET: Configuracoes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegerarPaginas()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            _PaginaApp.GerarPaginasCriadas(asm.ExportedTypes);
            _AcaoApp.GerarAcoesCriadas(asm.ExportedTypes);

            return RedirectToAction("Index", "Configuracoes");
        }
    }
}