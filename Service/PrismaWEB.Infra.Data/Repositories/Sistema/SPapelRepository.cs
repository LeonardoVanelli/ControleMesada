using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class SPapelRepository : RepositoryBase<SPapel>, ISPapelRepository
    {
        public IEnumerable<SPapel> BuscaNaoCadastradoPorPessoa(int IdPessoa)
        {
            return Db.S_Papel.SqlQuery("select p.* " +
                "from S_Papeis p " +
               "where p.Id not in (select Papel_Id " +
                                    "from S_PessoasPapeis " +
                                   "where Pessoa_Id = " + IdPessoa + ")");

            //select p.* from S_Papeis p where p.Id not in (select Papel_Id from S_PessoasPapeis where Pessoa_Id = 3)
            //var pessoaPapeis = Db.S_PessoasPapeis.Where(p => p.Pessoa_Id == IdPessoa).ToList();
            //IList<int> idPessoasPapeis = new List<int>();
            //foreach (var pessoaPapel in pessoaPapeis)
            //{
            //    idPessoasPapeis.Add(pessoaPapel.Papel_Id);
            //}

            //return Db.S_Papel.Where(p => !idPessoasPapeis.Contains(p.Id)).ToList();
        }

        public IEnumerable<SPapel> BuscaTodosPorPessoa(int IdPessoa)
        {
            return Db.S_Papel.SqlQuery("select p.* " +
                "from S_Papeis p, " +
                     "S_PessoasPapeis pp " +
                "where pp.Pessoa_Id = "+ IdPessoa +
                  "and p.Id = pp.Papel_Id " +
                  "and pp.Conceder = 1").ToList();
        }
    }
}

