using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class CidadeViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int Estado_Id { get; set; }
        [Required]

        [Display(Name = "País")]
        public int Pais_Id { get; set; }

        public virtual EstadoViewModel Estado { get; set; }
        public virtual PaisViewModel Pais { get; set; }
    }
}

