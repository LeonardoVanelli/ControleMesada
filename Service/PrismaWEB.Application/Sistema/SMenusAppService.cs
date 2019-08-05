using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities.Sistema;

namespace ProjetoModeloDDD.Application
{
    public class SMenusAppService : AppServiceBase<SMenus>, ISMenusAppService
    {
        private readonly ISMenusService _SMenusService;

        public SMenusAppService(ISMenusService SMenusService)
            : base(SMenusService)
        {
            _SMenusService = SMenusService;
        }
    }
}

