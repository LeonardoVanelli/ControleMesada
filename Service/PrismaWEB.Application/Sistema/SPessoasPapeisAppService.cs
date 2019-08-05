using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Application
{
    public class SPessoasPapeisAppService : AppServiceBase<SPessoasPapeis>, ISPessoasPapeisAppService
    {
        private readonly ISPessoasPapeisService _SPessoasPapeisService;

        public SPessoasPapeisAppService(ISPessoasPapeisService SPessoasPapeisService)
            : base(SPessoasPapeisService)
        {
            _SPessoasPapeisService = SPessoasPapeisService;
        }

        public IEnumerable<SPessoasPapeis> BuscarPorPessoa(int idPessoa)
        {
            return _SPessoasPapeisService.BuscarPorPessoa(idPessoa);
        }
    }
}

