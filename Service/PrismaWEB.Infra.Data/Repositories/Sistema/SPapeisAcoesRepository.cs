using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class SPapeisAcoesRepository : RepositoryBase<SPapeisAcoes>, ISPapeisAcoesRepository
    {
        public SPapeisAcoes BuscaPorPapelEAcao(int papelId, int acaoId)
        {
            return Db.S_PapeisAcoes.Where(p => p.Papel_Id == papelId && p.Acao_Id == acaoId).FirstOrDefault();
        }

        public bool PapeisTemAcessoAcao(string listaId, string nomeController)
        {
            var papesisAcoes = Db.S_PapeisAcoes.SqlQuery($@"select pa.* from S_PapeisAcoes pa 
                                                            inner join S_Acoes a on a.Id = pa.Acao_Id
                                                            and a.Pagina_Id in (select p.Id from S_Pagina p where p.Nome = '"+nomeController+@"')
                                                            and a.Nome = 'Create'
                                                            where pa.Papel_Id in ("+listaId+@")
                                                            and pa.Conceder = 1").FirstOrDefault();
            return papesisAcoes != null;

        }

        public SPapeisAcoes TemAcessoPorAcaoEPapel(int acaoId, int papelId)
        {
            return Db.S_PapeisAcoes.Where(p => p.Acao_Id == acaoId && p.Papel_Id == papelId).FirstOrDefault();
        }

    }
}

