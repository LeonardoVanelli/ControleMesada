using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoModeloDDD.Domain.Entities
{
    [Table("Leis")]
    public class Lei
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]        
        public string Numero { get; set; }

        [MaxLength(120)]
        [Required]
        public string Nome { get; set; }

        [Required]
        [MaxLength(450)]
        public string Descricao { get; set; }

        [Display(Name = "Autor")]
        public int Autor_Id { get; set; }

        [Required]
        [MaxLength(400)]
        public string LinkPdf { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        [ForeignKey("Autor_Id")]
        public virtual Pessoa Autor { get; set; }
    }
}
