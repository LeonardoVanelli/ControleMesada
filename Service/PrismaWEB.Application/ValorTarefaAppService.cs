using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;
using System;

namespace ProjetoModeloDDD.Application
{
    public class ValorTarefaAppService : AppServiceBase<ValorTarefa>, IValorTarefaAppService
    {
        private readonly IValorTarefaService _ValorTarefaService;

        public ValorTarefaAppService(IValorTarefaService ValorTarefaService)
            : base(ValorTarefaService)
        {
            _ValorTarefaService = ValorTarefaService;
        }

        public double BuscaValorTotalDaSemanaPorData(DateTime data)
        {
            return _ValorTarefaService.BuscaValorTotalDaSemanaPorData(data);
        }
    }
}

