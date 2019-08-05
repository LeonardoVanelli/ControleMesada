using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels.Sistema
{
    public class SUsuarioViewModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(120)]
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Apelido { get; set; }

        [Required]
        [MaxLength(60)]
        public string Login { get; set; }

        [Required]
        [MaxLength(60)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Digite novamente")]
        public string ValidaSenha { get; set; }

        public bool SenhasValidas()
        {
            return Senha == ValidaSenha;
        }
    }
}