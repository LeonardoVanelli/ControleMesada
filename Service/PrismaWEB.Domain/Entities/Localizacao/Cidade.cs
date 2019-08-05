namespace ProjetoModeloDDD.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Cidade
    {
        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string Nome { get; set; }

        public int Estado_Id { get; set; }
        [ForeignKey("Estado_Id")]
        public virtual Estado Estado { get; set; }
                
        public int Pais_Id { get; set; }
        [ForeignKey("Pais_Id")]
        public virtual Pais Pais { get; set; }
    }
}
