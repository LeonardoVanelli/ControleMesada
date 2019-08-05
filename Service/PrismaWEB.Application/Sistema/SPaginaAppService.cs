using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;
using System;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Application
{
    public class SPaginaAppService : AppServiceBase<SPagina>, ISPaginaAppService
    {
        private readonly ISPaginaService _SPaginaService;

        public SPaginaAppService(ISPaginaService SPaginaService)
            : base(SPaginaService)
        {
            _SPaginaService = SPaginaService;
        }

        public void GerarPaginasCriadas(IEnumerable<Type> exportedTypes)
        {
            _SPaginaService.DesativaTodasPaginas();
            var Paginas = new List<String>();
            foreach (var Pagina in exportedTypes)
            {
                if (Pagina.Namespace == "ProjetoModeloDDD.MVC.Controllers")
                {
                    _SPaginaService.AdicionaNovaPagina(Pagina.Name);
                }
            }
        }
    }
}

