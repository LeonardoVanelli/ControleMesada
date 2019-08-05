using System;
using System.Collections.Generic;
using PrismaWEB.Utils.Date;
using PrismaWEB.Utils.Exception;
using PrismaWEB.Utils.Querys;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Enum;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class AtividadeService : ServiceBase<Atividade>, IAtividadeService
    {
        private readonly IAtividadeRepository _AtividadeRepository;
        private readonly IQueryRepository _queryRepository;

        public AtividadeService(IAtividadeRepository AtividadeRepository, IQueryRepository queryRepository)
            : base(AtividadeRepository)
        {
            _AtividadeRepository = AtividadeRepository;
            _queryRepository = queryRepository;
        }

        #region Public
        public override void Add(Atividade obj)
        {

            ContemRegistroMesmaData(obj);
            DataSucessorAoDiaAtual(obj);
            base.Add(obj);
        }

        public IEnumerable<Atividade> GetByUser(int id)
        {
            return _AtividadeRepository.GetByUser(id);
        }

        public IEnumerable<Atividade> GetAllByDate(DateTime date)
        {
            return _AtividadeRepository.GetAllByDate(date);
        }

        public IEnumerable<object> RealizaFechamentoSemana(DateTime data)
        {
            var firstAndLastDay = DateHelper.GetFirstAndLastDayOfWeek(data);
            var sql = $@"select a.DataRealizada,
                               t.Nome,
	                           vt.Valor
                          from Atividade a,
                               Tarefa t,
                               ValorTarefa vt
                         where a.DataRealizada between '{firstAndLastDay.FirstDay}' and '{firstAndLastDay.LastDay}'
                           and a.Tarefa_Id = t.Id
                           and vt.Tarefa_Id = t.Id
                          order by a.DataRealizada";

            var queryList = _queryRepository.Get(sql);
            var relatorio = new List<Object>();


            foreach (var query in queryList)
            {
                relatorio.Add(new {
                    DataRealizada = query["DataRealizada"].ToDateTime(),
                    Nome = query["Nome"].ToString(),
                    Valor = query["Valor"].toDouble(),
                });
            }
            return relatorio;
        }

        public IEnumerable<QueryReseult> RealizaFechamentoSemana(int pessoa_Id, DateTime data)
        {
            var betwenn = MontaBetweenSemana(data);

            return _queryRepository.Get($@"select a.DataRealizada,
                                                     p.Nome NomePessoa,
                                                     t.Nome NomeTarefa,
                                                     vt.Valor
                                                from Atividade a,
                                                     Tarefa t,
                                                     ValorTarefa vt,
                                                     Pessoa p
                                               where a.Pessoa_Id = {pessoa_Id}
                                                 and a.Pessoa_Id = p.Id
                                                 and a.Tarefa_Id = t.Id
                                                 and vt.Tarefa_Id = t.Id
                                                 and a.DataRealizada BETWEEN {betwenn}");
        }
        #endregion

        #region private

        private string MontaBetweenSemana(DateTime data)
        {
            string between = $"'{data.AddDays(-7).ToString()}' and '{data.ToString()}'";

            return between;
        }

        private void ContemRegistroMesmaData(Atividade atividade)
        {
            if (_AtividadeRepository.ContemRegistroMesmaData(atividade))
                throw new EntidadeException("Esta atividade já foi inserida neste dia");
        }

        private void DataSucessorAoDiaAtual(Atividade obj)
        {
            if (obj.DataRealizada.Day > DateTime.Now.Day)
                throw new EntidadeException("Não é possivel cadastrar data depois do dia de hoje");
        }

        #endregion
    }
}

