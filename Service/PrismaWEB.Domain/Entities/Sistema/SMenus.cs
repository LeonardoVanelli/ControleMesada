using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoModeloDDD.Domain.Entities.Sistema
{
    [Table("S_Menus")]
    public class SMenus
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        public int? Tipo { get; set; }
    }
     
}
