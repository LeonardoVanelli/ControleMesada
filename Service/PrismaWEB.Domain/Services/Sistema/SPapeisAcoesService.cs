using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class SPapeisAcoesService : ServiceBase<SPapeisAcoes>, ISPapeisAcoesService
    {
        private readonly ISPapeisAcoesRepository _SPapeisAcoesRepository;

        public SPapeisAcoesService(ISPapeisAcoesRepository SPapeisAcoesRepository)
            : base(SPapeisAcoesRepository)
        {
            _SPapeisAcoesRepository = SPapeisAcoesRepository;
        }

        public void AlteraPermicao(int papelId, int acaoId)
        {
            var papelAcao = _SPapeisAcoesRepository.BuscaPorPapelEAcao(papelId, acaoId);
            if (papelAcao != null)
            {
                papelAcao.Conceder = !papelAcao.Conceder;
                Update(papelAcao);
            }
            else
            {
                papelAcao = new SPapeisAcoes()
                {
                    Acao_Id = acaoId,
                    Papel_Id = papelId,
                    Conceder = true
                };
                Add(papelAcao);
            }
        }

        public bool TemAcessoPorAcaoEPapel(int acaoId, int papelId)
        {
            var papelAcao = _SPapeisAcoesRepository.TemAcessoPorAcaoEPapel(acaoId, papelId);
            if (papelAcao == null)
                return false;
            return papelAcao.Conceder;
        }

        public bool PapeisTemAcessoAcao(IList<SPapel> papeis, string nomeController)
        {
            var listaId = "";            
            foreach (var papel in papeis)
            {
                listaId += listaId == "" ? "" : ", "; 
                listaId += papel.Id; 
            };
            return _SPapeisAcoesRepository.PapeisTemAcessoAcao(listaId, nomeController);
        }
    }
}