namespace ProjetoModeloDDD.Domain.Entities
{    
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Pessoa
    {
        public int Id { get; set; }

        [MaxLength(120)]
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        [Index(IsUnique = true)]
        public string Cpf { get; set; }

        public string Foto { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public bool Ativo { get; set; }

        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required]
        public string Apelido
        {
            get
            {
                if (Nome != null)
                {
                    var nomes = this.Nome.Split(' ');
                    return nomes.First() + " " + nomes.Last();                
                }
                return "";
            }
        }

        public string TelefoneFixo { get; set; }

        public string TelefoneMovel { get; set; }

        public string Endereco { get; set; }

        public int Pais_Id { get; set; }

        public int Estado_Id { get; set; }

        public int Cidade_Id { get; set; }

        public int Bairro_Id { get; set; }

        public int Logradouro_Id { get; set; }

        public string Cep { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public int? Tipo_Id { get; set; }


        [ForeignKey("Tipo_Id")]
        public virtual TipoPessoa Tipo { get; set; }
        [ForeignKey("Bairro_Id")]
        public virtual Bairro Bairro { get; set; }
        [ForeignKey("Cidade_Id")]
        public virtual Cidade Cidade { get; set; }
        [ForeignKey("Estado_Id")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("Logradouro_Id")]
        public virtual Logradouro Logradouro { get; set; }
        [ForeignKey("Pais_Id")]
        public virtual Pais Pais { get; set; }
    }
}
