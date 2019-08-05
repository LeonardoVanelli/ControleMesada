using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;

namespace ProjetoModeloDDD.Application
{
    public class EstadoAppService : AppServiceBase<Estado>, IEstadoAppService
    {
        private readonly IEstadoService _EstadoService;

        public EstadoAppService(IEstadoService EstadoService)
            : base(EstadoService)
        {
            _EstadoService = EstadoService;
        }
    }
}

