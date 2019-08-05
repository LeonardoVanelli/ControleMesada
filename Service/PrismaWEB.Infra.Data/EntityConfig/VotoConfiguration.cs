using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class VotoConfiguration : EntityTypeConfiguration<Voto>
    {
        public VotoConfiguration()
        {
            HasKey(p => p.Id);

            HasRequired(p => p.Usuario)
                .WithMany() 
                .HasForeignKey(p => p.Usuario_Id);

            HasRequired(p => p.Candidato)
                .WithMany()
                .HasForeignKey(p => p.Candidato_Id);

            Property(p => p.DataCriacao)
                .IsRequired();
        }
    }
}
