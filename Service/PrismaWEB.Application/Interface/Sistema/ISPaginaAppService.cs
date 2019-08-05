using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface ISPaginaAppService : IAppServiceBase<SPagina>
    {
        void GerarPaginasCriadas(IEnumerable<Type> exportedTypes);
    }
}

