using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class SPessoasPapeisService : ServiceBase<SPessoasPapeis>, ISPessoasPapeisService
    {
        private readonly ISPessoasPapeisRepository _SPessoasPapeisRepository;

        public SPessoasPapeisService(ISPessoasPapeisRepository SPessoasPapeisRepository)
            : base(SPessoasPapeisRepository)
        {
            _SPessoasPapeisRepository = SPessoasPapeisRepository;
        }

        public IEnumerable<SPessoasPapeis> BuscarPorPessoa(int idPessoa)
        {
            return _SPessoasPapeisRepository.BuscaPorPessoa(idPessoa);
        }
    }
}

