using PrismaWEB.Utils.Querys;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ProjetoModeloDDD.Infra.Data.Repositories.Sistema
{
    public class QueryRepository : IQueryRepository
    {
        // string de conexao
        readonly string conexao = WebConfigurationManager.ConnectionStrings["ProjetoModeloDDD"].ConnectionString;

        public IList<QueryReseult> Get(string sql)
        {
            using (var conn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand(sql, conn);
                List<object> dados = new List<object>();
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        IList<QueryReseult> result = new List<QueryReseult>();
                        while (reader.Read())
                        {
                            QueryReseult queryResult = new QueryReseult();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                if (reader[i] == DBNull.Value)
                                    queryResult.AdicionarCampo(null, reader.GetName(i));
                                else
                                    queryResult.AdicionarCampo(reader[i], reader.GetName(i));
                            }
                            result.Add(queryResult);
                        }
                        return result;
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void Add(QueryReseult obj)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<QueryReseult> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public QueryReseult GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(QueryReseult obj)
        {
            throw new System.NotImplementedException();
        }

        public void Update(QueryReseult obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
