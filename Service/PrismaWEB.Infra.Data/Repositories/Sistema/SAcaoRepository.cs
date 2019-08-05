using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class SAcaoRepository : RepositoryBase<SAcao>, ISAcaoRepository
    {
        public SPagina BuscaPaginaPorNome(string nomePagina)
        {
            return Db.S_Paginas.Where(p => p.Nome == nomePagina).FirstOrDefault();
        }

        public SAcao BuscaPorNomeEPagina(string nomeAcao, int idPagina)
        {
            return Db.S_Acoes.Where(a => a.Nome == nomeAcao && a.Pagina_Id == idPagina).FirstOrDefault();
        }

        public IEnumerable<SAcao> BuscaPorPagina(int IdPagina)
        {
            return Db.S_Acoes.Where(a => a.Pagina_Id == IdPagina && a.Ativa == true).ToList();
        }

        public void DesativaTodas()
        {
            Db.Database.ExecuteSqlCommand("Update S_Acoes set Ativa = 0");
        }
    }
}

