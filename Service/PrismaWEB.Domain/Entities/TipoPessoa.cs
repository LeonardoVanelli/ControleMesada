namespace ProjetoModeloDDD.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class TipoPessoa
    {
        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string Nome { get; set; }
        
        [Required]
        [MaxLength(180)]
        public string Descricao { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }        
    }
}
