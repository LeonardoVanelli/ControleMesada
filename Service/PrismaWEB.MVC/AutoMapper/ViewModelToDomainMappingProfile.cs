
using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Entities.Sistema;
using ProjetoModeloDDD.MVC.ViewModels;
using ProjetoModeloDDD.MVC.ViewModels.Sistema;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Cliente, ClienteViewModel>();
            Mapper.CreateMap<Produto, ProdutoViewModel>();
            Mapper.CreateMap<Pais, PaisViewModel>();
            Mapper.CreateMap<Pessoa, CandidatoViewModel>();
            Mapper.CreateMap<Pessoa, SUsuarioViewModel>();
            Mapper.CreateMap<Pessoa, SPessoaCadastroViewModel>();
            Mapper.CreateMap<Cargo, CargoViewModel>();
            Mapper.CreateMap<Presidente, PresidenteViewModel>();            
            Mapper.CreateMap<Lei, LeiViewModel>();
            Mapper.CreateMap<SAcao, SAcaoViewModel>();
            Mapper.CreateMap<SPagina, SPaginaViewModel>();
            Mapper.CreateMap<SPapeisAcoes, SPapeisAcoesViewModel>();
            Mapper.CreateMap<SPapel, SPapelViewModel>();
            Mapper.CreateMap<SPessoasPapeis, SPessoasPapeisViewModel>();
            Mapper.CreateMap<SCadastro, SCadastroViewModel>();
            Mapper.CreateMap<SCadastro, SUsuarioViewModel>();
            Mapper.CreateMap<SCadastro, SCadastroUsuarioLogadoViewModel>();
            Mapper.CreateMap<Pessoa, PessoaViewModel>();
            Mapper.CreateMap<SMenus, SMenusViewModel>();
            Mapper.CreateMap<SItensMenu, SItensMenuViewModel>();
            Mapper.CreateMap<TipoPessoa, TipoPessoaViewModel>();
            Mapper.CreateMap<Estado, EstadoViewModel>();
            Mapper.CreateMap<Cidade, CidadeViewModel>();
            Mapper.CreateMap<Bairro, BairroViewModel>();
            Mapper.CreateMap<Logradouro, LogradouroViewModel>();
            Mapper.CreateMap<Tarefa, TarefaViewModel>();
            Mapper.CreateMap<Atividade, AtividadeViewModel>();
            Mapper.CreateMap<ValorTarefa, ValorTarefaViewModel>();
        }
    }
}
























