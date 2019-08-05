using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;

namespace ProjetoModeloDDD.Application
{
    public class TarefaAppService : AppServiceBase<Tarefa>, ITarefaAppService
    {
        private readonly ITarefaService _TarefaService;

        public TarefaAppService(ITarefaService TarefaService)
            : base(TarefaService)
        {
            _TarefaService = TarefaService;
        }
    }
}

