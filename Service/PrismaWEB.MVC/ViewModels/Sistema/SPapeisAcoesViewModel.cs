using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class SPapeisAcoesViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ação")]
        public int Acao_Id { get; set; }
        public virtual SAcaoViewModel Acao { get; set; }

        [Required]
        [Display(Name = "Papel")]
        public int Papel_Id { get; set; }
        public virtual SPapelViewModel Papel { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Conceder { get; set; }        
    }
}

