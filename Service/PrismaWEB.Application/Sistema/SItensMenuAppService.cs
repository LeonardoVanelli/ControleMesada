using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities.Sistema;

namespace ProjetoModeloDDD.Application
{
    public class SItensMenuAppService : AppServiceBase<SItensMenu>, ISItensMenuAppService
    {
        private readonly ISItensMenuService _SItensMenuService;

        public SItensMenuAppService(ISItensMenuService SItensMenuService)
            : base(SItensMenuService)
        {
            _SItensMenuService = SItensMenuService;
        }
    }
}

