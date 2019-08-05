using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface ISCadastroAppService : IAppServiceBase<SCadastro>
    {
        SCadastro BuscaUsuarioLoginSenha(string login, string senha);

        SCadastro BuscaCadastroPorPessoa(int IdPessoa);

        bool SenhaIgualAnterior(int idPessoa, string senha);
    }
}

