namespace ProjetoModeloDDD.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("S_Acoes")]
    public class SAcao
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Required]
        public int Pagina_Id { get; set; }

        public string Url { get; set; }
        //-------
        [ForeignKey("Pagina_Id")]
        public virtual SPagina Pagina { get; set; }

        public bool Ativa { get; set; }
    }
}