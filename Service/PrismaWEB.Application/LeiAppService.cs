using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;

namespace ProjetoModeloDDD.Application
{
    public class LeiAppService : AppServiceBase<Lei>, ILeiAppService
    {
        private readonly ILeiService _LeiService;

        public LeiAppService(ILeiService LeiService)
            : base(LeiService)
        {
            _LeiService = LeiService;
        }
    }
}

