using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IPessoaService : IServiceBase<Pessoa>
    {
        IEnumerable<Pessoa> ObterCandidatos(IEnumerable<Pessoa> clientes);

        IEnumerable<Pessoa> BuscaPessoaComCadastro();

        void DesativarPessoa(int id);

        void AtivarPessoa(int id);

        void AddPesoaComCadastro(Pessoa pessoa, SCadastro cadastro);
    }
}

