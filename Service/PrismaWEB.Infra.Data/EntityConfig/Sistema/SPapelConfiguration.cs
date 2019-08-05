using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class SPapelConfiguration : EntityTypeConfiguration<SPapel>
    {
        public SPapelConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}

