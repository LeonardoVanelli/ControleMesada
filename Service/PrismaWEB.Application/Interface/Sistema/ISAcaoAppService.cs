using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface ISAcaoAppService : IAppServiceBase<SAcao>
    {
        void GerarAcoesCriadas(IEnumerable<Type> exportedTypes);

        IEnumerable<SAcao> BuscaPorPagina(int IdPagina);
    }
}

