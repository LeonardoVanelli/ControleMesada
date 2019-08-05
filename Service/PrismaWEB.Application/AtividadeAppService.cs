using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Application.Interface;
using System.Collections.Generic;
using PrismaWEB.Utils.Querys;
using ProjetoModeloDDD.Domain.Enum;
using System;

namespace ProjetoModeloDDD.Application
{
    public class AtividadeAppService : AppServiceBase<Atividade>, IAtividadeAppService
    {
        private readonly IAtividadeService _AtividadeService;

        public AtividadeAppService(IAtividadeService AtividadeService)
            : base(AtividadeService)
        {
            _AtividadeService = AtividadeService;
        }

        public IEnumerable<Atividade> GetAllByDate(DateTime date)
        {
            return _AtividadeService.GetAllByDate(date);
        }

        public IEnumerable<Atividade> GetByUser(int id)
        {
            return _AtividadeService.GetByUser(id);
        }

        public IEnumerable<QueryReseult> RealizaFechamentoSemana(int pessoa_Id, DateTime data)
        {            
            return _AtividadeService.RealizaFechamentoSemana(pessoa_Id, data);
        }

        public IEnumerable<object> RealizaFechamentoSemana(DateTime data)
        {
            return _AtividadeService.RealizaFechamentoSemana(data);
        }
    }
}

