namespace ProjetoModeloDDD.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("S_PessoasPapeis")]
    public class SPessoasPapeis
    {
        public int Id { get; set; }

        [Required]
        public int Pessoa_Id { get; set; }

        [Required]
        public int Papel_Id { get; set; }

        [Required]
        public bool Conceder { get; set; }
        //-------
        [ForeignKey("Pessoa_Id")]
        public virtual Pessoa Pessoa { get; set; }

        [ForeignKey("Papel_Id")]
        public virtual SPapel Papel { get; set; }
    }
}