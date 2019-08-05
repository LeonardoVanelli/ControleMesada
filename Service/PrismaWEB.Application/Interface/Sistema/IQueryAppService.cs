using PrismaWEB.Utils.Querys;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Application.Interface.Sistema
{
    public interface IQueryAppService : IAppServiceBase<QueryReseult>
    {
        IEnumerable<QueryReseult> Get(string sql);
    }
}
