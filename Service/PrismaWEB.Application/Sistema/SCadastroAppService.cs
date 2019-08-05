using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;

namespace ProjetoModeloDDD.Application
{
    public class SCadastroAppService : AppServiceBase<SCadastro>, ISCadastroAppService
    {
        private readonly ISCadastroService _SCadastroService;

        public SCadastroAppService(ISCadastroService SCadastroService)
            : base(SCadastroService)
        {
            _SCadastroService = SCadastroService;
        }

        public SCadastro BuscaCadastroPorPessoa(int IdPessoa)
        {
            return _SCadastroService.BuscaCadastroPorPessoa(IdPessoa);
        }

        public SCadastro BuscaUsuarioLoginSenha(string login, string senha)
        {
            return _SCadastroService.BuscaUsuarioLoginSenha(login, senha);
        }

        public bool SenhaIgualAnterior(int idPessoa, string senha)
        {
            return _SCadastroService.SenhaIgualAnterior(idPessoa, senha);
        }
    }
}

