using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProjetoModeloDDD.Application
{
    public class SAcaoAppService : AppServiceBase<SAcao>, ISAcaoAppService
    {
        private readonly ISAcaoService _SAcaoService;

        public SAcaoAppService(ISAcaoService SAcaoService)
            : base(SAcaoService)
        {
            _SAcaoService = SAcaoService;
        }

        public IEnumerable<SAcao> BuscaPorPagina(int IdPagina)
        {
            return _SAcaoService.BuscaPorPagina(IdPagina);
        }

        public void GerarAcoesCriadas(IEnumerable<Type> exportedTypes)
        {
            _SAcaoService.DesativaTodas();
            foreach (var Pagina in exportedTypes)
            {
                if (Pagina.Namespace == "ProjetoModeloDDD.MVC.Controllers")
                {
                    var QPagina = _SAcaoService.BuscaPaginaPorNome(Pagina.Name.Substring(0, Pagina.Name.Length - 10));              

                    foreach (var action in ((TypeInfo)Pagina).DeclaredMethods)
                    {
                        var acao = _SAcaoService.BuscaPorNomeEPagina(action.Name, QPagina.Id);
                        if (acao == null)
                        {
                            SAcao novaAcao = new SAcao()
                            {
                                Nome = action.Name,
                                Pagina = QPagina,
                                Url = QPagina.Nome + "/" + action.Name,
                                Ativa = true
                            };

                            _SAcaoService.Add(novaAcao);
                        }
                        else
                            _SAcaoService.AtivaAcao(acao);                            
                    }                     
                }
            }            
        }
    }
}

