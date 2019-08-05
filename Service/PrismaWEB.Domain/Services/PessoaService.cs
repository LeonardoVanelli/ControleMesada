using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Enum;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class PessoaService : ServiceBase<Pessoa>, IPessoaService
    {
        private readonly ISCadastroService _CadastroService;
        private readonly IPessoaRepository _PessoaRepository;        

        public PessoaService(IPessoaRepository PessoaRepository, ISCadastroService CadastroService)
            : base(PessoaRepository)
        {
            _PessoaRepository = PessoaRepository;
            _CadastroService = CadastroService;
        }
        
        public void AddPesoaComCadastro(Pessoa pessoa, SCadastro cadastro)
        {            
            if (cadastro == null)
            {
                _PessoaRepository.Add(pessoa);
            }
            else
            {
                _CadastroService.Validate(cadastro);
                _PessoaRepository.Add(pessoa);
                cadastro.Pessoa_Id = pessoa.Id;
                _CadastroService.Add(cadastro);
            }
        }

        public void AtivarPessoa(int id)
        {
            var pessoa = _PessoaRepository.GetById(id);
            pessoa.Ativo = true;
            _PessoaRepository.Update(pessoa);            
        }

        public IEnumerable<Pessoa> BuscaPessoaComCadastro()
        {
            return _PessoaRepository.BuscaPessoaComCadastro();
        }

        public void DesativarPessoa(int id)
        {
            var pessoa = _PessoaRepository.GetById(id);
            pessoa.Ativo = false;
            _PessoaRepository.Update(pessoa);
        }

        public IEnumerable<Pessoa> ObterCandidatos(IEnumerable<Pessoa> Pessoas)
        {
            return Pessoas.Where(p => p.Tipo == new TipoPessoa());
        }
    }
}

