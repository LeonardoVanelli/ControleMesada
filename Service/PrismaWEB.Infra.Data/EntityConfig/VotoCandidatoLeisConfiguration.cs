

using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class VotoCandidatoLeisConfiguration : EntityTypeConfiguration<Votocandidatoleis>
    {
        public VotoCandidatoLeisConfiguration()
        {
            HasKey(p => p.Id);

            HasRequired(p => p.Candidato)
                .WithMany()
                .HasForeignKey(p => p.Candidato_Id);

            HasRequired(p => p.Lei)
                .WithMany()
                .HasForeignKey(p => p.Lei_Id);

            Property(p => p.Votou)
                .IsRequired();                

            Property(p => p.DataCriacao)
                .IsRequired();
        }
    }
}

