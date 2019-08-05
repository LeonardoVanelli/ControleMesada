using System;
using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface IAtividadeRepository : IRepositoryBase<Atividade>
    {
        bool ContemRegistroMesmaData(Atividade atividade);
        IEnumerable<Atividade> GetByUser(int id);
        IEnumerable<Atividade> GetAllByDate(DateTime date);
    }
}

