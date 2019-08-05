
using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Entities.Sistema;
using ProjetoModeloDDD.MVC.ViewModels;
using ProjetoModeloDDD.MVC.ViewModels.Sistema;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<ProdutoViewModel, Produto>();
            Mapper.CreateMap<PaisViewModel, Pais>();
            Mapper.CreateMap<CandidatoViewModel, Pessoa>();
            Mapper.CreateMap<SUsuarioViewModel, Pessoa>();
            Mapper.CreateMap<SPessoaCadastroViewModel, Pessoa>();
            Mapper.CreateMap<PresidenteViewModel, Presidente>();
            Mapper.CreateMap<CargoViewModel, Cargo>();
            Mapper.CreateMap<LeiViewModel, Lei>();
            Mapper.CreateMap<SAcaoViewModel, SAcao>();
            Mapper.CreateMap<SPaginaViewModel, SPagina>();
            Mapper.CreateMap<SPapeisAcoesViewModel, SPapeisAcoes>();
            Mapper.CreateMap<SPapelViewModel, SPapel>();
            Mapper.CreateMap<SPessoasPapeisViewModel, SPessoasPapeis>();
            Mapper.CreateMap<SCadastroViewModel, SCadastro>();
            Mapper.CreateMap<SCadastroUsuarioLogadoViewModel, SCadastro>();
            Mapper.CreateMap<SUsuarioViewModel, SCadastro>();
            Mapper.CreateMap<PessoaViewModel, Pessoa>();
            Mapper.CreateMap<SMenusViewModel, SMenus>();
            Mapper.CreateMap<SItensMenuViewModel, SItensMenu>();
            Mapper.CreateMap<TipoPessoaViewModel, TipoPessoa>();
            Mapper.CreateMap<EstadoViewModel, Estado>();
            Mapper.CreateMap<CidadeViewModel, Cidade>();
            Mapper.CreateMap<BairroViewModel, Bairro>();
            Mapper.CreateMap<LogradouroViewModel, Logradouro>();
            Mapper.CreateMap<TarefaViewModel, Tarefa>();
            Mapper.CreateMap<AtividadeViewModel, Atividade>();
            Mapper.CreateMap<ValorTarefaViewModel, ValorTarefa>();
        }
    }
}

























