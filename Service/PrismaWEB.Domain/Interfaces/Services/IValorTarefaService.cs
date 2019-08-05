using System;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IValorTarefaService : IServiceBase<ValorTarefa>
    {
        double BuscaValorTotalDaSemanaPorData(DateTime data);
    }
}

