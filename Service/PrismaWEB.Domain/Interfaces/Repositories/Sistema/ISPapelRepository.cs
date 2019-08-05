using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface ISPapelRepository : IRepositoryBase<SPapel>
    {
        IEnumerable<SPapel> BuscaTodosPorPessoa(int IdPessoa);

        IEnumerable<SPapel> BuscaNaoCadastradoPorPessoa(int IdPessoa);
    }
}

