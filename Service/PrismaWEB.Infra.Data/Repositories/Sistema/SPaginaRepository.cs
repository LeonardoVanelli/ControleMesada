using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class SPaginaRepository : RepositoryBase<SPagina>, ISPaginaRepository
    {
        public int BuscaQtdPaginaPorNome(string nomePagina)
        {            
            return Db.S_Paginas.Where(p => p.Nome == nomePagina).ToList().Count();            
        }

        public SPagina BuscaPorNome(string nomePagina)
        {
            return Db.S_Paginas.Where(p => p.Nome == nomePagina).FirstOrDefault();
        }

        public void DesativaTodasPaginas()
        {
            Db.Database.ExecuteSqlCommand("UPDATE S_Pagina SET Ativa = 0");
            Db.SaveChanges();
        }
    }
}

