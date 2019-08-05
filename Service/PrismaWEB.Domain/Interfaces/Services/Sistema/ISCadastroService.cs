using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface ISCadastroService : IServiceBase<SCadastro>
    {
        SCadastro BuscaUsuarioLoginSenha(string login, string senha);        

        SCadastro BuscaCadastroPorPessoa(int idPessoa);

        bool SenhaIgualAnterior(int idPessoa, string senha);

        void Validate(SCadastro cadastro);
    }
}

