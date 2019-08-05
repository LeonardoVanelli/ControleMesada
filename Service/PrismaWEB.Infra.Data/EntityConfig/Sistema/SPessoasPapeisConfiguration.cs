using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class SPessoasPapeisConfiguration : EntityTypeConfiguration<SPessoasPapeis>
    {
        public SPessoasPapeisConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}

