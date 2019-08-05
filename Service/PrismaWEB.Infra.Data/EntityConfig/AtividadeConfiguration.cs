using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class AtividadeConfiguration : EntityTypeConfiguration<Atividade>
    {
        public AtividadeConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}

