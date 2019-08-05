using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Entities.Sistema;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class SMenusConfiguration : EntityTypeConfiguration<SMenus>
    {
        public SMenusConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}

