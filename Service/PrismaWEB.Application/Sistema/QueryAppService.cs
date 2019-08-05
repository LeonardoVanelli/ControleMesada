using PrismaWEB.Utils.Querys;
using ProjetoModeloDDD.Application.Interface.Sistema;
using ProjetoModeloDDD.Domain.Interfaces.Services.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application.Sistema
{
    public class QueryAppService : AppServiceBase<QueryReseult>, IQueryAppService
    {
        private readonly IQueryService _queryService;

        public QueryAppService(IQueryService queryService)
            : base(queryService)
        {
            _queryService = queryService;
        }

        public IEnumerable<QueryReseult> Get(string sql)
        {
            return _queryService.Get(sql);
        }
    }
}
