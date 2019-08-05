namespace ProjetoModeloDDD.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tarefa
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        [Index(IsUnique = true)]
        public string Nome { get; set; }
        [Required]
        [StringLength(420)]
        public string Descricao { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }
    }
}
