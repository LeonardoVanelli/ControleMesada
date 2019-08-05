using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class CidadeService : ServiceBase<Cidade>, ICidadeService
    {
        private readonly ICidadeRepository _CidadeRepository;

        public CidadeService(ICidadeRepository CidadeRepository)
            : base(CidadeRepository)
        {
            _CidadeRepository = CidadeRepository;
        }
    }
}

