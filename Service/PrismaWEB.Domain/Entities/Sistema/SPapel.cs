namespace ProjetoModeloDDD.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("S_Papeis")]
    public class SPapel
    {
        public int Id { get; set; }

        [MaxLength(60)]
        [Required]
        [Index(IsUnique = true)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(450)]     
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
    }
}