using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class BairroViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 4)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        public int Cidade_Id { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int Estado_Id { get; set; }

        [Required]
        [Display(Name = "País")]
        public int Pais_Id { get; set; }

        public virtual CidadeViewModel Cidade { get; set; }
        public virtual EstadoViewModel Estado { get; set; }
        public virtual PaisViewModel Pais { get; set; }
    }
}

