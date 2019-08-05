using PrismaWEB.Utils.Querys;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface IQueryRepository : IRepositoryBase<QueryReseult>
    {
        IList<QueryReseult> Get(string sql);
    }
}
