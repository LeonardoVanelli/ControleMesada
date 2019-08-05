using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface ISAcaoRepository : IRepositoryBase<SAcao>
    {
        SPagina BuscaPaginaPorNome(string nomePagina);

        IEnumerable<SAcao> BuscaPorPagina(int IdPagina);

        SAcao BuscaPorNomeEPagina(string nomeAcao, int idPagina);

        void DesativaTodas();
    }
}

