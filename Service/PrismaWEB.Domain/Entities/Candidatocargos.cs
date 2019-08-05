namespace ProjetoModeloDDD.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Candidatocargos
    {
        public int Id { get; set; }

        public int Candidato_Id { get; set; }

        public int Cargo_Id { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public int Status { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public virtual Cargo Cargos { get; set; }

        public virtual Pessoa Pessoas { get; set; }
    }
}
