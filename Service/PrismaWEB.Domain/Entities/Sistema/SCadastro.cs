namespace ProjetoModeloDDD.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("S_Cadastros")]
    public class SCadastro
    {
        public int Id { get; set; }

        [Required]
        public int Pessoa_Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Login { get; set; }

        [Required]
        [MaxLength(60)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }        

        public DateTime? UltimoAcesso { get; set; }
        [Required]        
        public DateTime DataCriacao { get; set; }

        [Required]        
        public bool AlterarSenha { get; set; }
        //-------
        [ForeignKey("Pessoa_Id")]
        public virtual Pessoa Pessoa { get; set; }
    }
}