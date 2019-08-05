using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface ISCadastroRepository : IRepositoryBase<SCadastro>
    {
        IList<SCadastro> BuscaUltimoRegistroTodosUsuariosPorLogin(string login);

        SCadastro BuscaCadastroPorPessoa(int idPessoa);
    }
}

