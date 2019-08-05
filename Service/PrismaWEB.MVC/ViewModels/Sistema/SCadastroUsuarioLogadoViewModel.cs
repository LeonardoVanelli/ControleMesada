using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels.Sistema
{
    public class SCadastroUsuarioLogadoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pessoa")]
        public int Pessoa_Id { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }

        [Required]
        [MaxLength(60)]
        public string Login { get; set; }

        [Required]
        [MaxLength(60)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public IList<SPapelViewModel> Papeis { get; set; }
    }
}