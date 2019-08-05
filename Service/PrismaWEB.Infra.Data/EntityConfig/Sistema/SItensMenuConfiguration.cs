using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Entities.Sistema;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class SItensMenuConfiguration : EntityTypeConfiguration<SItensMenu>
    {
        public SItensMenuConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}

