using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class BairroService : ServiceBase<Bairro>, IBairroService
    {
        private readonly IBairroRepository _BairroRepository;

        public BairroService(IBairroRepository BairroRepository)
            : base(BairroRepository)
        {
            _BairroRepository = BairroRepository;
        }
    }
}

