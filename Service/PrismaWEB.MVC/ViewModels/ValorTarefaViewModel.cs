using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ValorTarefaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Valor { get; set; }

        [Required]
        public int Tarefa_Id { get; set; }
        public virtual TarefaViewModel Tarefa { get; set; }

    }
}

