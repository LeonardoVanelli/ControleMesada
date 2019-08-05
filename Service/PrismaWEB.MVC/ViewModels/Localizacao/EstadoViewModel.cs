using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class EstadoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(75)]
        public string Nome { get; set; }

        [Required]
        [StringLength(2)]
        public string Uf { get; set; }

        [Required]
        public int Pais_Id { get; set; }
        public virtual PaisViewModel Pais { get; set; }
    }
}

