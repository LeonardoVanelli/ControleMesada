using PrismaWEB.Utils.Date;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class AtividadeRepository : RepositoryBase<Atividade>, IAtividadeRepository
    {
        public bool ContemRegistroMesmaData(Atividade atividade)
        {
            var numeroAtividades = Db.Atividades.Where(a => a.Tarefa_Id == atividade.Tarefa_Id &&
                                     a.DataRealizada.Year == atividade.DataRealizada.Year &&
                                     a.DataRealizada.Month == atividade.DataRealizada.Month &&
                                     a.DataRealizada.Day == atividade.DataRealizada.Day)
                .Count();

            return numeroAtividades == 0 ? false : true;
        }

        public IEnumerable<Atividade> GetAllByDate(DateTime date)
        {
            return Db.Atividades.Where(a => a.DataRealizada.Year == date.Year &&
                                            a.DataRealizada.Month == date.Month &&
                                            a.DataRealizada.Day == date.Day).ToList();
        }

        public IEnumerable<Atividade> GetByUser(int id)
        {
            return Db.Atividades.Where(a => a.Pessoa_Id == id);
        }

        private bool MesmoDia(DateTime date, DateTime date2)
        {
            if (date.Year == date2.Year &&
                date.Month == date2.Month &&
                date.Day == date2.Day)
            {
                return true;
            }
            return false;
        }
    }
}

