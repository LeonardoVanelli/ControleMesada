using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class EstadoService : ServiceBase<Estado>, IEstadoService
    {
        private readonly IEstadoRepository _EstadoRepository;

        public EstadoService(IEstadoRepository EstadoRepository)
            : base(EstadoRepository)
        {
            _EstadoRepository = EstadoRepository;
        }
    }
}

