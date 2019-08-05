using ProjetoModeloDDD.Domain.Attribute;
using ProjetoModeloDDD.MVC.ViewModels.ValidationAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class CandidatoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        [VisivelView]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date)]
        [VisivelView(Campos = "Form, Details, Edit")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataNascimento { get; set; }

        [Required]       
        [Cpf]
        [Display(Name = "CPF")]
        [VisivelView(Campos = "Form, Details, Edit")]
        public string Cpf { get; set; }

        public string Foto { get; set; }

        [Required]
        [VisivelView(Campos = "Form, Details, Edit")]        
        public bool Ativo { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress]
        [VisivelView]
        [StringLength(60, MinimumLength = 5)]
        public string Email { get; set; }

        [Display(Name = "Telefone Fixo")]
        [VisivelView(Campos = "Form, Details, Edit")]
        public string TelefoneFixo { get; set; }

        [Display(Name = "Telefone Movel")]
        [VisivelView]
        public string TelefoneMovel { get; set; }

        [Required]
        [Display(Name = "País")]
        [ForeignKeyView("Pais", "Nome")]
        [VisivelView]
        public int Pais_Id { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [ForeignKeyView("Estado", "Nome")]
        [VisivelView(Campos = "Form, Details, Edit")]
        public int Estado_Id { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        [ForeignKeyView("Cidade", "Nome")]
        [VisivelView(Campos = "Form, Details, Edit")]
        public int Cidade_Id { get; set; }

        [Display(Name = "Bairro")]
        [ForeignKeyView("Bairro", "Nome")]
        [VisivelView(Campos = "Form, Details, Edit")]
        public int Bairro_Id { get; set; }

        [Display(Name = "Logradouro")]
        [ForeignKeyView("Logradouro", "Nome")]
        [VisivelView(Campos = "Form, Details, Edit")]
        public int Logradouro_Id { get; set; }

        [MaxLength(8)]
        [VisivelView(Campos = "Form, Details, Edit")]
        public string Cep { get; set; }

        [MaxLength(6)]
        [VisivelView(Campos = "Form, Details, Edit")]
        public string Numero { get; set; }

        [MaxLength(250)]
        [VisivelView(Campos = "Form, Details, Edit")]

        public string Complemento { get; set; }

        //public virtual BairroViewModel Bairro { get; set; }        
        //public virtual Cidade Cidade { get; set; }        
        //public virtual Estado Estado { get; set; }        
        //public virtual Logradouro Logradouro { get; set; }        
        public virtual PaisViewModel Pais { get; set; }
    }
}

