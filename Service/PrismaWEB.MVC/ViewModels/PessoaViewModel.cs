using ProjetoModeloDDD.Domain.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class PessoaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Data Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
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

        [Required]
        public string Apelido { get; set; }

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

        public TipoPessoaViewModel Tipo { get; set; }

        public virtual BairroViewModel Bairro { get; set; }
        //public virtual CidadeViewModel Cidade { get; set; }
        //public virtual EstadoViewModel Estado { get; set; }
        public virtual LogradouroViewModel Logradouro { get; set; }
        public virtual PaisViewModel Pais { get; set; }
    }
}