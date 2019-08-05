using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface ISPapeisAcoesService : IServiceBase<SPapeisAcoes>
    {
        void AlteraPermicao(int papelId, int acaoId);

        bool TemAcessoPorAcaoEPapel(int acaoId, int papelId);

        bool PapeisTemAcessoAcao(IList<SPapel> papeis, string nomeController);
    }
}

