using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface ISPapelService : IServiceBase<SPapel>
    {
        IEnumerable<SPapel> BuscaTodosPorPessoa(int IdPessoa);

        IEnumerable<SPapel> BuscaNaoCadastradoPorPessoa(int idPessoa);
    }
}

