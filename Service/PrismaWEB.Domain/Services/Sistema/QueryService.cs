namespace ProjetoModeloDDD.Domain.Services.Sistema
{
    using PrismaWEB.Utils.Querys;
    using ProjetoModeloDDD.Domain.Interfaces.Repositories;
    using ProjetoModeloDDD.Domain.Interfaces.Services.Sistema;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class QueryService : ServiceBase<QueryReseult>, IQueryService
    {
        private readonly IQueryRepository _SAcaoRepository;

        public QueryService(IQueryRepository QueryRepository)
            : base(QueryRepository)
        {
            _SAcaoRepository = QueryRepository;
        }

        public IList<QueryReseult> Get(string sql)
        {
            return _SAcaoRepository.Get(sql);
        }
    }
}
