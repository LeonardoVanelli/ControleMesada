namespace ProjetoModeloDDD.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ValorTarefa
    {
        public int Id { get; set; }

        [Required]
        public double Valor { get; set; }

        [Required]
        public int Tarefa_Id { get; set; }
        [ForeignKey("Tarefa_Id")]
        public virtual Tarefa Tarefa { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

    }
}
