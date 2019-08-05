using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;

namespace ProjetoModeloDDD.Application
{
    public class BairroAppService : AppServiceBase<Bairro>, IBairroAppService
    {
        private readonly IBairroService _BairroService;

        public BairroAppService(IBairroService BairroService)
            : base(BairroService)
        {
            _BairroService = BairroService;
        }
    }
}

