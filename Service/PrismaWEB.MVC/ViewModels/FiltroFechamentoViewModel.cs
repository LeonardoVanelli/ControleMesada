using ProjetoModeloDDD.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;


namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class FiltroFechamentoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public TipoPeriodo Periodo { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Data { get; set; }

        [Required]
        [Display(Name = "Funcionário")]
        public int Pessoa_Id { get; set; }
        [Display(Name = "Usuario para fechamento")]
        public virtual PessoaViewModel Pessoa { get; set; }
    }

    public enum TipoPeriodo
    {
        Dia = 0,
        Semana,
        Mes,
        Ano
    }
}