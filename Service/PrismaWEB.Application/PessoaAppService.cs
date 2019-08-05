using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class PessoaAppService : AppServiceBase<Pessoa>, IPessoaAppService
    {
        private readonly IPessoaService _PessoaService;

        public PessoaAppService(IPessoaService PessoaService)
            : base(PessoaService)
        {
            _PessoaService = PessoaService;
        }

        public void AddPesoaComCadastro(Pessoa pessoa, SCadastro cadastro)
        {
            _PessoaService.AddPesoaComCadastro(pessoa, cadastro);
        }

        public void AtivarPessoa(int idPessoa)
        {
            _PessoaService.AtivarPessoa(idPessoa);
        }

        public IEnumerable<Pessoa> BuscaPessoaComCadastro()
        {
            return _PessoaService.BuscaPessoaComCadastro();
        }

        public void DesativarPessoa(int idPessoa)
        {
            _PessoaService.DesativarPessoa(idPessoa);            
        }

        public IEnumerable<Pessoa> ObterCandidatos()
        {
            return _PessoaService.ObterCandidatos(_PessoaService.GetAll());
        }
    }
}

