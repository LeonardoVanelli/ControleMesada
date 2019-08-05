using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class SAcaoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }        

        public string Url { get; set; }
        //-------
        [Required]
        [Display(Name = "Pagina")]
        public int Pagina_Id { get; set; }
        public virtual SPaginaViewModel Pagina { get; set; }
    }
}

