using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface ISPaginaService : IServiceBase<SPagina>
    {
        void AdicionaNovaPagina(string nomePagina);

        void AtivaPagina(SPagina pagina);

        void DesativaTodasPaginas();
    }
}

