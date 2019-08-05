using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;

namespace ProjetoModeloDDD.Application
{
    public class CargoAppService : AppServiceBase<Cargo>, ICargoAppService
    {
        private readonly ICargoService _CargoService;

        public CargoAppService(ICargoService CargoService)
            : base(CargoService)
        {
            _CargoService = CargoService;
        }
    }
}

