using ProjetoModeloDDD.Application;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Domain.Services;
using ProjetoModeloDDD.Infra.Data.Repositories;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ProjetoModeloDDD.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ProjetoModeloDDD.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace ProjetoModeloDDD.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using ProjetoModeloDDD.Application.Interface.Sistema;
    using ProjetoModeloDDD.Application.Sistema;
    using ProjetoModeloDDD.Domain.Interfaces.Services.Sistema;
    using ProjetoModeloDDD.Domain.Services.Sistema;
    using ProjetoModeloDDD.Infra.Data.Repositories.Sistema;
    using ProjetoModeloDDD.MVC.Atributos;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernell = new StandardKernel();
            try
            {
                kernell.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernell.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernell);
                return kernell;
            }
            catch
            {
                kernell.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IClienteAppService>().To<ClienteAppService>();
            kernel.Bind<IProdutoAppService>().To<ProdutoAppService>();
            kernel.Bind<IPaisAppService>().To<PaisAppService>();
            kernel.Bind<IPessoaAppService>().To<PessoaAppService>();
            kernel.Bind<ICargoAppService>().To<CargoAppService>();
            kernel.Bind<IPresidenteAppService>().To<PresidenteAppService>();
            kernel.Bind<ILeiAppService>().To<LeiAppService>();
            kernel.Bind<ISAcaoAppService>().To<SAcaoAppService>();
            kernel.Bind<ISPaginaAppService>().To<SPaginaAppService>();
            kernel.Bind<ISPapeisAcoesAppService>().To<SPapeisAcoesAppService>();
            kernel.Bind<ISPapelAppService>().To<SPapelAppService>();
            kernel.Bind<ISPessoasPapeisAppService>().To<SPessoasPapeisAppService>();
            kernel.Bind<ISCadastroAppService>().To<SCadastroAppService>();
            kernel.Bind<ISMenusAppService>().To<SMenusAppService>();
            kernel.Bind<ISItensMenuAppService>().To<SItensMenuAppService>();
            kernel.Bind<ITipoPessoaAppService>().To<TipoPessoaAppService>();
            kernel.Bind<IEstadoAppService>().To<EstadoAppService>();
            kernel.Bind<ICidadeAppService>().To<CidadeAppService>();
            kernel.Bind<IBairroAppService>().To<BairroAppService>();
            kernel.Bind<ILogradouroAppService>().To<LogradouroAppService>();
            kernel.Bind<ITarefaAppService>().To<TarefaAppService>();
            kernel.Bind<IAtividadeAppService>().To<AtividadeAppService>();
            kernel.Bind<IValorTarefaAppService>().To<ValorTarefaAppService>();
            kernel.Bind<IQueryAppService>().To<QueryAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IClienteService>().To<ClienteService>();
            kernel.Bind<IProdutoService>().To<ProdutoService>();
            kernel.Bind<IPaisService>().To<PaisService>();
            kernel.Bind<IPessoaService>().To<PessoaService>();
            kernel.Bind<IPresidenteService>().To<PresidenteService>();
            kernel.Bind<ICargoService>().To<CargoService>();
            kernel.Bind<ILeiService>().To<LeiService>();
            kernel.Bind<ISAcaoService>().To<SAcaoService>();
            kernel.Bind<ISPaginaService>().To<SPaginaService>();
            kernel.Bind<ISPapeisAcoesService>().To<SPapeisAcoesService>();
            kernel.Bind<ISPapelService>().To<SPapelService>();
            kernel.Bind<ISPessoasPapeisService>().To<SPessoasPapeisService>();
            kernel.Bind<ISCadastroService>().To<SCadastroService>();
            kernel.Bind<ISMenusService>().To<SMenusService>();
            kernel.Bind<ISItensMenuService>().To<SItensMenuService>();
            kernel.Bind<ITipoPessoaService>().To<TipoPessoaService>();
            kernel.Bind<IEstadoService>().To<EstadoService>();
            kernel.Bind<ICidadeService>().To<CidadeService>();
            kernel.Bind<IBairroService>().To<BairroService>();
            kernel.Bind<ILogradouroService>().To<LogradouroService>();
            kernel.Bind<ITarefaService>().To<TarefaService>();
            kernel.Bind<IAtividadeService>().To<AtividadeService>();
            kernel.Bind<IValorTarefaService>().To<ValorTarefaService>();
            kernel.Bind<IQueryService>().To<QueryService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IClienteRepository>().To<ClienteRepository>();
            kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();
            kernel.Bind<IPaisRepository>().To<PaisRepository>();
            kernel.Bind<IPessoaRepository>().To<PessoaRepository>();
            kernel.Bind<IPresidenteRepository>().To<PresidenteRepository>();
            kernel.Bind<ICargoRepository>().To<CargoRepository>();
            kernel.Bind<ILeiRepository>().To<LeiRepository>();
            kernel.Bind<ISAcaoRepository>().To<SAcaoRepository>();
            kernel.Bind<ISPaginaRepository>().To<SPaginaRepository>();
            kernel.Bind<ISPapeisAcoesRepository>().To<SPapeisAcoesRepository>();
            kernel.Bind<ISPapelRepository>().To<SPapelRepository>();
            kernel.Bind<ISPessoasPapeisRepository>().To<SPessoasPapeisRepository>();
            kernel.Bind<ISCadastroRepository>().To<SCadastroRepository>();
            kernel.Bind<ISMenusRepository>().To<SMenusRepository>();
            kernel.Bind<ISItensMenuRepository>().To<SItensMenuRepository>();
            kernel.Bind<ITipoPessoaRepository>().To<TipoPessoaRepository>();
            kernel.Bind<IEstadoRepository>().To<EstadoRepository>();
            kernel.Bind<ICidadeRepository>().To<CidadeRepository>();
            kernel.Bind<IBairroRepository>().To<BairroRepository>();
            kernel.Bind<ILogradouroRepository>().To<LogradouroRepository>();
            kernel.Bind<IQueryRepository>().To<QueryRepository>();
            kernel.Bind<ITarefaRepository>().To<TarefaRepository>();
            kernel.Bind<IAtividadeRepository>().To<AtividadeRepository>();
            kernel.Bind<IValorTarefaRepository>().To<ValorTarefaRepository>();

        }
    }
}



























