namespace ProjetoModeloDDD.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Cargo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        [Index(IsUnique = true)]
        public string Nome { get; set; }
        [Required]
        [StringLength(420)]
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
