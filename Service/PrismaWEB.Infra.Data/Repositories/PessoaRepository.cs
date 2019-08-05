using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        public IEnumerable<Pessoa> BuscaPessoaComCadastro()
        {
            return Db.Pessoas.SqlQuery("select * from Pessoa p where p.Id in (select Pessoa_id from S_Cadastros)").ToList();
        }
    }
}

