using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class LogradouroService : ServiceBase<Logradouro>, ILogradouroService
    {
        private readonly ILogradouroRepository _LogradouroRepository;

        public LogradouroService(ILogradouroRepository LogradouroRepository)
            : base(LogradouroRepository)
        {
            _LogradouroRepository = LogradouroRepository;
        }
    }
}

