using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class CargoService : ServiceBase<Cargo>, ICargoService
    {
        private readonly ICargoRepository _CargoRepository;

        public CargoService(ICargoRepository CargoRepository)
            : base(CargoRepository)
        {
            _CargoRepository = CargoRepository;
        }
    }
}

