using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;

namespace ProjetoModeloDDD.Application
{
    public class LogradouroAppService : AppServiceBase<Logradouro>, ILogradouroAppService
    {
        private readonly ILogradouroService _LogradouroService;

        public LogradouroAppService(ILogradouroService LogradouroService)
            : base(LogradouroService)
        {
            _LogradouroService = LogradouroService;
        }
    }
}

