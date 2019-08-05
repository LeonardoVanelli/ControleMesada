using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class SPapelService : ServiceBase<SPapel>, ISPapelService
    {
        private readonly ISPapelRepository _SPapelRepository;

        public SPapelService(ISPapelRepository SPapelRepository)
            : base(SPapelRepository)
        {
            _SPapelRepository = SPapelRepository;
        }

        public IEnumerable<SPapel> BuscaTodosPorPessoa(int IdPessoa)
        {
            return _SPapelRepository.BuscaTodosPorPessoa(IdPessoa);
        }

        public IEnumerable<SPapel> BuscaNaoCadastradoPorPessoa(int idPessoa)
        {
            return _SPapelRepository.BuscaNaoCadastradoPorPessoa(idPessoa);
        }
    }
}

