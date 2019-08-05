using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class LogradouroConfiguration : EntityTypeConfiguration<Logradouro>
    {
        public LogradouroConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}

