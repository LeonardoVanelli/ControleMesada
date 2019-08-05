using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class AtividadeViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataRealizada { get; set; }

        [Required]
        public int Pessoa_Id { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }

        [Required]
        public int Tarefa_Id { get; set; }        
        public virtual TarefaViewModel Tarefa { get; set; }

    }
}

