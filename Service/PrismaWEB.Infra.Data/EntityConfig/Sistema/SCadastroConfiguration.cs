using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class SCadastroConfiguration : EntityTypeConfiguration<SCadastro>
    {
        public SCadastroConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}

