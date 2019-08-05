using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class SPaginaService : ServiceBase<SPagina>, ISPaginaService
    {
        private readonly ISPaginaRepository _SPaginaRepository;

        public SPaginaService(ISPaginaRepository SPaginaRepository)
            : base(SPaginaRepository)
        {
            _SPaginaRepository = SPaginaRepository;
        }

        public void AdicionaNovaPagina(string NomeController)
        {
            var nomePagina = NomeController.Substring(0, NomeController.Length - 10);
            var PaginaCadastrada = _SPaginaRepository.BuscaPorNome(nomePagina);
            if (PaginaCadastrada == null)
            {
                var pagina = new SPagina()
                {
                    Nome = nomePagina,
                    Controller = nomePagina,
                    Ativa = true
                };

                _SPaginaRepository.Add(pagina);
            }
            else
                AtivaPagina(PaginaCadastrada);            
        }

        public void AtivaPagina(SPagina pagina)
        {
            pagina.Ativa = true;
            _SPaginaRepository.Update(pagina);
        }

        public void DesativaTodasPaginas()
        {
            _SPaginaRepository.DesativaTodasPaginas();
        }
    }
}

