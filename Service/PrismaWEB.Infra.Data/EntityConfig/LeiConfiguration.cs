using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class LeiConfiguration : EntityTypeConfiguration<Lei>
    {
        public LeiConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Nome).
                IsRequired();

            Property(x => x.Numero).
                IsRequired();

            Property(x => x.Descricao).
                IsRequired();

            Property(x => x.LinkPdf).
                IsRequired();

            Property(x => x.DataCriacao).
                IsRequired();
        }
    }
}

