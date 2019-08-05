using ProjetoModeloDDD.Domain.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class CargoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        [VisivelView(Campos = "Grid, Form")]
        public string Nome { get; set; }
        [Required]
        [StringLength(420)]
        [Display(Name = "Descrição")]
        [VisivelView(Campos = "Grid, Form")]
        public string Descricao { get; set; }        
    }
}

