using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class TipoPessoaService : ServiceBase<TipoPessoa>, ITipoPessoaService
    {
        private readonly ITipoPessoaRepository _TipoPessoaRepository;

        public TipoPessoaService(ITipoPessoaRepository TipoPessoaRepository)
            : base(TipoPessoaRepository)
        {
            _TipoPessoaRepository = TipoPessoaRepository;
        }

        public override void Add(TipoPessoa obj)
        {
            obj.Ativo = true;
            base.Add(obj);
        }
    }
}