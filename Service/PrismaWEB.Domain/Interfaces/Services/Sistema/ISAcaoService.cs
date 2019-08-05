using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface ISAcaoService : IServiceBase<SAcao>
    {
        SPagina BuscaPaginaPorNome(string nomePagina);

        IEnumerable<SAcao> BuscaPorPagina(int IdPagina);

        SAcao BuscaPorNomeEPagina(string nomeAcao, int idPagina);

        void AtivaAcao(SAcao acao);

        void DesativaTodas();
    }
}

