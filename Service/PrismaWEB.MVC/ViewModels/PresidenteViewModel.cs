using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class PresidenteViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataNascimento { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string Cpf { get; set; }
        public string Foto { get; set; }
        [Required]
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
    }
}

