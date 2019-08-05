namespace ProjetoModeloDDD.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("S_Pagina")]
    public class SPagina
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Required]
        public string Controller { get; set; }

        public string Url { get; set; }

        [Required]
        public bool Ativa { get; set; }
    }
}