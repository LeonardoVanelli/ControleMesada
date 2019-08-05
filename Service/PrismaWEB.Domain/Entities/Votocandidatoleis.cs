namespace ProjetoModeloDDD.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Votocandidatoleis
    {
        public int Id { get; set; }
        public int Candidato_Id { get; set; }
        public int Lei_Id { get; set; }
        public bool Votou { get; set; }
        public DateTime DataCriacao { get; set; }

        public virtual Lei Lei { get; set; }
        public virtual Pessoa Candidato { get; set; }
    }
}
