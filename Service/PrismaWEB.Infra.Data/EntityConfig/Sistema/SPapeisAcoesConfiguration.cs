using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class SPapeisAcoesConfiguration : EntityTypeConfiguration<SPapeisAcoes>
    {
        public SPapeisAcoesConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}

