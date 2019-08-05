using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class SPapelViewModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(60)]
        [Required]
        public string Nome { get; set; }

        [Required]
        [MaxLength(450)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public virtual IList<SAcaoViewModel> Acoes { get; set; }
    }
}

