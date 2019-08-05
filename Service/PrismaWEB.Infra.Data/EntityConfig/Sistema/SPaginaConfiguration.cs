using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class SPaginaConfiguration : EntityTypeConfiguration<SPagina>
    {
        public SPaginaConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}

