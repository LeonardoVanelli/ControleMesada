using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface ISPapelAppService : IAppServiceBase<SPapel>
    {
        IEnumerable<SPapel> BuscaTodosPorPessoa(int IdPessoa);

        IEnumerable<SPapel> BuscaNaoCadastradoPorPessoa(int idPessoa);
    }
}

