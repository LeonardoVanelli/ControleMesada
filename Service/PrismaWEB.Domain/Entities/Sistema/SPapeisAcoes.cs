namespace ProjetoModeloDDD.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("S_PapeisAcoes")]
    public class SPapeisAcoes
    {
        public int Id { get; set; }

        [Required]
        public int Acao_Id { get; set; }

        [Required]
        public int Papel_Id { get; set; }

        [Required]
        public bool Conceder { get; set; }
        //-------

        [ForeignKey("Acao_Id")]
        public virtual SAcao Acao { get; set; }

        [ForeignKey("Papel_Id")]
        public virtual SPapel Papel { get; set; }
    }
}