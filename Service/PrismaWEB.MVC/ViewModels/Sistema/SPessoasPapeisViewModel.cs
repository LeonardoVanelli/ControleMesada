using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class SPessoasPapeisViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pessoa")]
        public int Pessoa_Id { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }

        [Required]
        [Display(Name = "Papel")]
        public int Papel_Id { get; set; }
        public virtual SPapelViewModel Papel { get; set; }

        [Required]
        public bool Conceder { get; set; }                
    }
}

