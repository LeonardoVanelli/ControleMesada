using System;
using System.Collections.Generic;
using PrismaWEB.Utils.Querys;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Enum;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IAtividadeService : IServiceBase<Atividade>
    {
        IEnumerable<Atividade> GetByUser(int id);
        IEnumerable<QueryReseult> RealizaFechamentoSemana(int pessoa_Id, DateTime data);
        IEnumerable<object> RealizaFechamentoSemana(DateTime data);
        IEnumerable<Atividade> GetAllByDate(DateTime date);
    }
}

