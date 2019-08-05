using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Entities.Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class SItensMenuViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(60)]
        [Display(Name = "Texto", Description = "Texto que aparecera no botão")]
        public string Caption { get; set; }

        [Required]
        public Tipo Tipo { get; set; }

        public string Url { get; set; }

        [Display(Name = "Item Pai")]
        public int? ItemPai_Id { get; set; }

        public virtual SItensMenu ItemPai { get; set; }

        [Display(Name = "Action")]
        public int? Action_Id { get; set; }

        public virtual SAcao Action { get; set; }

        [Display(Name = "Menu")]
        public int Menu_Id { get; set; }
        
        public virtual SMenus Menu { get; set; }
    }
}

