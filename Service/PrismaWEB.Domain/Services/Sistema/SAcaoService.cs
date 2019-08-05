using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class SAcaoService : ServiceBase<SAcao>, ISAcaoService
    {
        private readonly ISAcaoRepository _SAcaoRepository;

        public SAcaoService(ISAcaoRepository SAcaoRepository)
            : base(SAcaoRepository)
        {
            _SAcaoRepository = SAcaoRepository;
        }

        public SPagina BuscaPaginaPorNome(string nomePagina)
        {
            return _SAcaoRepository.BuscaPaginaPorNome(nomePagina);
        }

        public IEnumerable<SAcao> BuscaPorPagina(int IdPagina)
        {
            return _SAcaoRepository.BuscaPorPagina(IdPagina);
        }

        public void AtivaAcao(SAcao acao)
        {
            acao.Ativa = true;
            _SAcaoRepository.Update(acao);
        }

        public SAcao BuscaPorNomeEPagina(string nomeAcao, int idPagina)
        {
            return _SAcaoRepository.BuscaPorNomeEPagina(nomeAcao, idPagina);
        }

        public void DesativaTodas()
        {
            _SAcaoRepository.DesativaTodas();
        }
    }
}

