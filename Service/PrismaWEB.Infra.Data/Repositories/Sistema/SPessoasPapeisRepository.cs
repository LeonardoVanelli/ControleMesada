using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class SPessoasPapeisRepository : RepositoryBase<SPessoasPapeis>, ISPessoasPapeisRepository
    {
        public IEnumerable<SPessoasPapeis> BuscaPorPessoa(int idPessoa)
        {
            return Db.S_PessoasPapeis.Where(p => p.Pessoa_Id == idPessoa).ToList();
        }

        public bool UsuarioTemPermicao(int IdUsuario, string action, string controller)
        {
            var pessoaPapeis = Db.S_PessoasPapeis.Where(p => p.Pessoa_Id == IdUsuario).ToList();
            

            if (pessoaPapeis == null)
                return false;

            IList<int> idPessoasPapeis = new List<int>();
            foreach (var pessoaPapel in pessoaPapeis)
            {
                idPessoasPapeis.Add(pessoaPapel.Papel_Id);
            }

            //Verifica se usuario tem acesso
            var usuarioTemAcesso = Db.S_PapeisAcoes.Where(p => idPessoasPapeis.Contains(p.Papel_Id) && p.Acao_Id == (
                                            Db.S_Acoes.Where(a => a.Pagina_Id == (
                                            Db.S_Paginas.Where(c => c.Nome == controller).FirstOrDefault().Id)
                                            && a.Nome == action).FirstOrDefault().Id)
                                            && p.Conceder == true).FirstOrDefault();

            if (usuarioTemAcesso != null)            
                return true;
            return false;
        }
    }
}

