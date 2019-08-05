using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;

namespace ProjetoModeloDDD.Application
{
    public class TipoPessoaAppService : AppServiceBase<TipoPessoa>, ITipoPessoaAppService
    {
        private readonly ITipoPessoaService _TipoPessoaService;

        public TipoPessoaAppService(ITipoPessoaService TipoPessoaService)
            : base(TipoPessoaService)
        {
            _TipoPessoaService = TipoPessoaService;
        }
    }
}

