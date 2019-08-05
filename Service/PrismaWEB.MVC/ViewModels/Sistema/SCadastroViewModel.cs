using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class SCadastroViewModel
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
 
        [DataType(DataType.Password)]
        [Display(Name = "Senha anterior")]
        public string SenhaAnterior { get; set; }

        [Required]
        [MaxLength(60)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Digite novamente")]
        public string ValidaSenha { get; set; }

        [Required]
        public bool AlterarSenha { get; set; }

        public bool SenhasValidas()
        {
            return Senha == ValidaSenha;
        }
    }
}

