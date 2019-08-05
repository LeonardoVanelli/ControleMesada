using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class PresidenteService : ServiceBase<Presidente>, IPresidenteService
    {
        private readonly IPresidenteRepository _PresidenteRepository;

        public PresidenteService(IPresidenteRepository PresidenteRepository)
            : base(PresidenteRepository)
        {
            _PresidenteRepository = PresidenteRepository;
        }
    }
}

