using System.Collections.Generic;
using PrismaWEB.Utils.Exception;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class LeiService : ServiceBase<Lei>, ILeiService
    {
        private readonly ILeiRepository _LeiRepository;

        public LeiService(ILeiRepository LeiRepository)
            : base(LeiRepository)
        {
            _LeiRepository = LeiRepository;
        }
    }
}

