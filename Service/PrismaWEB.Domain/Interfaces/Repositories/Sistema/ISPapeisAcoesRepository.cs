using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface ISPapeisAcoesRepository : IRepositoryBase<SPapeisAcoes>
    {
        SPapeisAcoes BuscaPorPapelEAcao(int papelId, int acaoId);

        SPapeisAcoes TemAcessoPorAcaoEPapel(int acaoId, int papelId);
        bool PapeisTemAcessoAcao(string listaId, string nomeController);
    }
}

