using ProjetoModeloDDD.Application;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Infra.Data.Repositories;

namespace ProjetoModeloDDD.MVC.Atributos
{
    public static class PapelPermitido
    {
        public static bool UsuarioTemAcesso(int IdUsuario, string action, string controller)
        {
            SPessoasPapeisRepository pessoaRepository = new SPessoasPapeisRepository();
            return pessoaRepository.UsuarioTemPermicao(IdUsuario, action, controller);            
        }
    }
}