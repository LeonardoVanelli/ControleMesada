using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface ISPaginaRepository : IRepositoryBase<SPagina>
    {
        int BuscaQtdPaginaPorNome(string nomePagina);

        SPagina BuscaPorNome(string nomePagina);

        void DesativaTodasPaginas();
    }
}

