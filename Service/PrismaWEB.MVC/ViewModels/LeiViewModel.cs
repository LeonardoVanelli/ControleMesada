using ProjetoModeloDDD.Domain.Attribute;
using ProjetoModeloDDD.MVC.ViewModels.ValidationAttribute;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class LeiViewModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        [VisivelView]
        public string Numero { get; set; }

        [MaxLength(120)]
        [Required]        
        [VisivelView]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        [MaxLength(450)]
        [VisivelView]
        public string Descricao { get; set; }

        [ForeignKeyView("Pessoa", "Nome")]
        [VisivelView]
        public int Autor_Id { get; set; }

        [Required]
        [MaxLength(400)]
        [VisivelView]
        public string LinkPdf { get; set; }

        public virtual CandidatoViewModel Autor { get; set; }
    }
}

