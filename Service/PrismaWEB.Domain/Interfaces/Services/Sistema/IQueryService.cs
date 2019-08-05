namespace ProjetoModeloDDD.Domain.Interfaces.Services.Sistema
{
    using PrismaWEB.Utils.Querys;
    using ProjetoModeloDDD.Domain.Interfaces.Repositories;
    using ProjetoModeloDDD.Domain.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IQueryService : IServiceBase<QueryReseult>
    {
        IList<QueryReseult> Get(string sql);
    }
}
