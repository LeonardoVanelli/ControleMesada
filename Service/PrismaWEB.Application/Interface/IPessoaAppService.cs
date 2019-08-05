using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IPessoaAppService : IAppServiceBase<Pessoa>
    {
        IEnumerable<Pessoa> ObterCandidatos();

        IEnumerable<Pessoa> BuscaPessoaComCadastro();

        void AtivarPessoa(int idPessoa);

        void DesativarPessoa(int idPessoa);

        void AddPesoaComCadastro(Pessoa pessoa, SCadastro cadastro);
    }
}

