namespace ProjetoModeloDDD.Infra.Data.Migrations
{
    using ProjetoModeloDDD.Domain.Entities;
    using ProjetoModeloDDD.Infra.Data.Contexto;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjetoModeloDDD.Infra.Data.Contexto.ProjetoModeloContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjetoModeloContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.            
            //if (context.Paises.ToList().Count == 0)
            //{

                //context.Paises.AddOrUpdate(new Pais()
                //{
                //    Nome = "Brasil",
                //    Sigla = "BR"
                //});

                //context.Estados.AddOrUpdate(new Estado()
                //{
                //    Nome = "Brasilia",
                //    Pais_Id = 1,
                //    Uf = "SC"
                //});

                //context.Cidades.AddOrUpdate(new Cidade()
                //    {
                //        Nome = "Blumenau",
                //        Estado_Id = 1
                //    });

                //context.Bairros.AddOrUpdate(new ProjetoModeloDDD.Domain.Entities.Bairro()
                //{
                //    Nome = "Garcia",
                //    Pais_Id = 1,
                //    Estado_Id = 1,
                //    Cidade_Id = 1
                //});

                //context.Logradouros.AddOrUpdate(new Logradouro()
                //{
                //    Nome = "Rua Amazonas",
                //    Pais = 1,
                //    Estado = 1,
                //    Cidade = 1,
                //    Bairro = 1
                //});

                //context.TipoPessoas.AddOrUpdate(new ProjetoModeloDDD.Domain.Entities.TipoPessoa()
                //{
                //    Nome = "Funcionario",
                //    Descricao = "Funcionario",
                //    Ativo = true                          
                //});

                //context.Pessoas.AddOrUpdate(new ProjetoModeloDDD.Domain.Entities.Pessoa()
                //{
                //    Nome = "Desenvolvedor Admin",
                //    DataNascimento = DateTime.Now,
                //    Cpf = "93529090972",
                //    Ativo = true,
                //    Email = "Admin@admin.com.br",
                //    Pais_Id = 1,
                //    Estado_Id = 1,
                //    Cidade_Id = 1,
                //    Bairro_Id = 1,
                //    Logradouro_Id = 1
                //});

                //context.S_Cadastros.AddOrUpdate(new SCadastro()
                //{
                //    Pessoa_Id = 1,
                //    Login = "Admin123",
                //    Senha = "Admin123"
                //});

                //context.S_Papel.AddOrUpdate(new SPapel()
                //{
                //    Nome = "Desenvolvedor",
                //    Descricao = "Desenvolver"
                //});

                //context.S_PessoasPapeis.AddOrUpdate(new SPessoasPapeis()
                //{
                //    Pessoa_Id = 1,
                //    Papel_Id = 1,
                //    Conceder = true
                //});
            //}
        }
    }
}
