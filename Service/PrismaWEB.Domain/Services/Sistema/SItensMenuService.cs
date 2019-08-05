using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Entities.Sistema;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class SItensMenuService : ServiceBase<SItensMenu>, ISItensMenuService
    {
        private readonly ISItensMenuRepository _SItensMenuRepository;

        public SItensMenuService(ISItensMenuRepository SItensMenuRepository)
            : base(SItensMenuRepository)
        {
            _SItensMenuRepository = SItensMenuRepository;
        }
    }
}

