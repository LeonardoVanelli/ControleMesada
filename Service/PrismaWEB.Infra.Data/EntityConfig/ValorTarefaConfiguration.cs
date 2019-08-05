using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class ValorTarefaConfiguration : EntityTypeConfiguration<ValorTarefa>
    {
        public ValorTarefaConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}

