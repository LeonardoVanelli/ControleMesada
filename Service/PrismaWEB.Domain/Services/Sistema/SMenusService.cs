using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Entities.Sistema;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class SMenusService : ServiceBase<SMenus>, ISMenusService
    {
        private readonly ISMenusRepository _SMenusRepository;

        public SMenusService(ISMenusRepository SMenusRepository)
            : base(SMenusRepository)
        {
            _SMenusRepository = SMenusRepository;
        }
    }
}

