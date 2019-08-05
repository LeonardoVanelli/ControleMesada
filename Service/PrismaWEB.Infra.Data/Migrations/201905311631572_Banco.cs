namespace ProjetoModeloDDD.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Banco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atividade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataRealizada = c.DateTime(nullable: false),
                        Pessoa_Id = c.Int(nullable: false),
                        Tarefa_Id = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoa", t => t.Pessoa_Id)
                .ForeignKey("dbo.Tarefa", t => t.Tarefa_Id)
                .Index(t => t.Pessoa_Id)
                .Index(t => t.Tarefa_Id);
            
            CreateTable(
                "dbo.Tarefa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 420, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nome, unique: true);
            
            CreateTable(
                "dbo.ValorTarefa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.Double(nullable: false),
                        Tarefa_Id = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tarefa", t => t.Tarefa_Id)
                .Index(t => t.Tarefa_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ValorTarefa", "Tarefa_Id", "dbo.Tarefa");
            DropForeignKey("dbo.Atividade", "Tarefa_Id", "dbo.Tarefa");
            DropForeignKey("dbo.Atividade", "Pessoa_Id", "dbo.Pessoa");
            DropIndex("dbo.ValorTarefa", new[] { "Tarefa_Id" });
            DropIndex("dbo.Tarefa", new[] { "Nome" });
            DropIndex("dbo.Atividade", new[] { "Tarefa_Id" });
            DropIndex("dbo.Atividade", new[] { "Pessoa_Id" });
            DropTable("dbo.ValorTarefa");
            DropTable("dbo.Tarefa");
            DropTable("dbo.Atividade");
        }
    }
}
