using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class PaisService : ServiceBase<Pais>, IPaisService
    {
        private readonly IPaisRepository _PaisRepository;

        public PaisService(IPaisRepository PaisRepository)
            : base(PaisRepository)
        {
            _PaisRepository = PaisRepository;
        }
    }
}

