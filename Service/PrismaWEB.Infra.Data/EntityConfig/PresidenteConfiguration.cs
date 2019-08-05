using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class PresidenteConfiguration : EntityTypeConfiguration<Presidente>
    {
        public PresidenteConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}

