using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Application
{
    public class SPapeisAcoesAppService : AppServiceBase<SPapeisAcoes>, ISPapeisAcoesAppService
    {
        private readonly ISPapeisAcoesService _SPapeisAcoesService;

        public SPapeisAcoesAppService(ISPapeisAcoesService SPapeisAcoesService)
            : base(SPapeisAcoesService)
        {
            _SPapeisAcoesService = SPapeisAcoesService;
        }

        public void AlteraPermicao(int papelId, int acaoId)
        {
            _SPapeisAcoesService.AlteraPermicao(papelId, acaoId);
        }

        public bool PapeisTemAcessoAcao(IList<SPapel> papeis, string nomeController)
        {
            return _SPapeisAcoesService.PapeisTemAcessoAcao(papeis, nomeController);
        }

        public bool TemAcessoPorAcaoEPapel(int acaoId, int papelId)
        {
            return _SPapeisAcoesService.TemAcessoPorAcaoEPapel(acaoId, papelId);
        }
    }
}

