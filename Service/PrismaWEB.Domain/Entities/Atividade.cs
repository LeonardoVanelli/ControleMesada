namespace ProjetoModeloDDD.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Atividade
    {
        public int Id { get; set; }

        [Required]
        public DateTime DataRealizada { get; set; }

        [Required]
        public int Pessoa_Id { get; set; }
        [ForeignKey("Pessoa_Id")]
        public virtual Pessoa Pessoa { get; set; }

        [Required]
        public int Tarefa_Id { get; set; }
        [ForeignKey("Tarefa_Id")]
        public virtual Tarefa Tarefa { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
