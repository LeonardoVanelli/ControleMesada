using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class TipoPessoaConfiguration : EntityTypeConfiguration<TipoPessoa>
    {
        public TipoPessoaConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}

