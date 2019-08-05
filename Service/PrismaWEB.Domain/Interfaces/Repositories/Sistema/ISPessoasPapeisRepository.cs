using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface ISPessoasPapeisRepository : IRepositoryBase<SPessoasPapeis>
    {
        bool UsuarioTemPermicao(int IdUsuario, string action, string controller);

        IEnumerable<SPessoasPapeis> BuscaPorPessoa(int idPessoa);
    }
}

