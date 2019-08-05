using System;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class ValorTarefaService : ServiceBase<ValorTarefa>, IValorTarefaService
    {
        private readonly IValorTarefaRepository _ValorTarefaRepository;
        private readonly IQueryRepository _QueryRepository;

        public ValorTarefaService(IValorTarefaRepository ValorTarefaRepository, IQueryRepository QueryRepository)
            : base(ValorTarefaRepository)
        {
            _ValorTarefaRepository = ValorTarefaRepository;
            _QueryRepository = QueryRepository;
        }

        public double BuscaValorTotalDaSemanaPorData(DateTime data)
        {
            var firstAndLastDay = PrismaWEB.Utils.Date.DateHelper.GetFirstAndLastDayOfWeek(data);

            var sql = $@"select sum(vt.Valor) ValorTotal 
                           from Atividade a, 
                                ValorTarefa vt 
                          where a.Tarefa_Id = vt.Tarefa_Id 
                            and a.DataRealizada between '{firstAndLastDay.FirstDay.ToString("dd/MM/yyyy")}' and '{firstAndLastDay.LastDay.ToString("dd/MM/yyyy")}'";
            var queryResult = _QueryRepository.Get(sql).FirstOrDefault();

            if (queryResult["ValorTotal"] != null)
                return queryResult["ValorTotal"].toDouble();
            return 0;

        }
    }
}

