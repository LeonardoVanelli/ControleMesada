using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface ISPapeisAcoesAppService : IAppServiceBase<SPapeisAcoes>
    {
        void AlteraPermicao(int papelId, int acaoId);
        bool TemAcessoPorAcaoEPapel(int acaoId, int papelId);
        bool PapeisTemAcessoAcao(IList<SPapel> papeis, string nomeController);
    }
}

