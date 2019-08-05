namespace ProjetoModeloDDD.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Bairro
    {    
        public int Id { get; set; }

        [Required]
        [StringLength(120,MinimumLength=4)]
        public string Nome { get; set; }

        [Required]
        public int Cidade_Id { get; set; }
        [ForeignKey("Cidade_Id")]
        public virtual Cidade Cidade { get; set; }

        [Required]
        public int Estado_Id { get; set; }
        [ForeignKey("Estado_Id")]
        public virtual Estado Estado { get; set; }

        [Required]
        public int Pais_Id { get; set; }
        [ForeignKey("Pais_Id")]
        public virtual Pais Pais { get; set; }
    }
}
