using AutoMapper;
using PrismaWEB.Utils.Exception;
using ProjetoModeloDDD.Domain.Attribute;
using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels.Sistema
{
    public class SPessoaCadastroViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date)]        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [Required]
        [Cpf(ErrorMessage = "CPF Inválido")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [DataType(DataType.Upload)]
        public string Foto { get; set; }

        [Required]
        [Display(Name = "Usuario Ativo")]
        public bool Ativo { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress]
        [StringLength(60, MinimumLength = 5)]
        public string Email { get; set; }

        [Display(Name = "Telefone Fixo")]
        public string TelefoneFixo { get; set; }

        [Display(Name = "Telefone Movel")]
        public string TelefoneMovel { get; set; }

        [Required]
        [Display(Name = "País")]
        public int Pais_Id { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int Estado_Id { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        public int Cidade_Id { get; set; }

        [Display(Name = "Bairro")]
        public int Bairro_Id { get; set; }

        [Display(Name = "Logradouro")]
        public int Logradouro_Id { get; set; }

        [MaxLength(8)]
        public string Cep { get; set; }

        [MaxLength(6)]
        public string Numero { get; set; }

        [MaxLength(250)]
        public string Complemento { get; set; }

        public int Tipo_Id { get; set; }

        [MaxLength(60)]
        public string Login { get; set; }

        [MaxLength(60)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Digite novamente")]
        public string ValidaSenha { get; set; }

        public bool AlterarSenha { get; set; }

        public TipoPessoaViewModel Tipo { get; set; }
        public virtual BairroViewModel Bairro { get; set; }        
        //public virtual CidadeViewModel Cidade { get; set; }        
        //public virtual EstadoViewModel Estado { get; set; }        
        public virtual LogradouroViewModel Logradouro { get; set; }        
        public virtual PaisViewModel Pais { get; set; }

        public bool TemCadastro()
        {            
            return this.Login != null || this.Senha != null;
        }

        internal SCadastro MontaCadastro()
        {
            if (!TemCadastro())
                return null;
            var cadastroVM = new SCadastroViewModel()
            {
                Login = this.Login,
                Senha = this.Senha,
                ValidaSenha = this.ValidaSenha,
                AlterarSenha = this.AlterarSenha
            };
            if (!cadastroVM.SenhasValidas())
                throw new EntidadeException("Senhas não são iguais", nameof(this.Senha));

            return Mapper.Map<SCadastroViewModel, SCadastro>(cadastroVM);
        }

        internal Pessoa MontaPessoa()
        {
            var pessoaDomain = Mapper.Map<SPessoaCadastroViewModel, Pessoa>(this);
            pessoaDomain.Tipo_Id = 1;

            return pessoaDomain;
        }
    }
}