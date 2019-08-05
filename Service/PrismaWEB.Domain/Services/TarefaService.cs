using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class TarefaService : ServiceBase<Tarefa>, ITarefaService
    {
        private readonly ITarefaRepository _TarefaRepository;

        public TarefaService(ITarefaRepository TarefaRepository)
            : base(TarefaRepository)
        {
            _TarefaRepository = TarefaRepository;
        }
    }
}

