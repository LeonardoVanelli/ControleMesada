using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface ISPessoasPapeisAppService : IAppServiceBase<SPessoasPapeis>
    {
        IEnumerable<SPessoasPapeis> BuscarPorPessoa(int idPessoa);
    }
}

