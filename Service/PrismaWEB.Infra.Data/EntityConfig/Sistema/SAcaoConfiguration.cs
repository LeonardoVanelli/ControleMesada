using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class SAcaoConfiguration : EntityTypeConfiguration<SAcao>
    {
        public SAcaoConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}

