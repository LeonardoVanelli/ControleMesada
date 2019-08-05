using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;

namespace ProjetoModeloDDD.Application
{
    public class PresidenteAppService : AppServiceBase<Presidente>, IPresidenteAppService
    {
        private readonly IPresidenteService _PresidenteService;

        public PresidenteAppService(IPresidenteService PresidenteService)
            : base(PresidenteService)
        {
            _PresidenteService = PresidenteService;
        }
    }
}

