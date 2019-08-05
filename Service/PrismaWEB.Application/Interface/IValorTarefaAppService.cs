using System;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IValorTarefaAppService : IAppServiceBase<ValorTarefa>
    {
        double BuscaValorTotalDaSemanaPorData(DateTime data);
    }
}

