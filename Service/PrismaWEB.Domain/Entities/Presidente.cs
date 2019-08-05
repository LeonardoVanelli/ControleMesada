namespace ProjetoModeloDDD.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Presidente
    {
        public int Id { get; set; }
        public int Candidato_Id { get; set; }
        public int Vice_Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }

        public virtual Pessoa Candidato { get; set; }
        public virtual Pessoa Vice { get; set; }
    }
}
