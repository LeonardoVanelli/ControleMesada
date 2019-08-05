using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Application
{
    public class SPapelAppService : AppServiceBase<SPapel>, ISPapelAppService
    {
        private readonly ISPapelService _SPapelService;

        public SPapelAppService(ISPapelService SPapelService)
            : base(SPapelService)
        {
            _SPapelService = SPapelService;
        }

        public IEnumerable<SPapel> BuscaNaoCadastradoPorPessoa(int idPessoa)
        {
            return _SPapelService.BuscaNaoCadastradoPorPessoa(idPessoa);

        }

        public IEnumerable<SPapel> BuscaTodosPorPessoa(int IdPessoa)
        {
            return _SPapelService.BuscaTodosPorPessoa(IdPessoa);
        }
    }
}

