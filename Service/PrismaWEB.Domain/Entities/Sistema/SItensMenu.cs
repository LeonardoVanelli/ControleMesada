using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoModeloDDD.Domain.Entities.Sistema
{
    [Table("S_ItensMenu")]
    public class SItensMenu
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(60)]
        public string Caption { get; set; }

        [Required]
        public Tipo Tipo { get; set; }

        public string url { get; set; }

        public int? ItemPai_Id { get; set; }
        [ForeignKey("ItemPai_Id")]
        public virtual SItensMenu ItemPai { get; set; }

        public int? Action_Id { get; set; }
        [ForeignKey("Action_Id")]
        public SAcao action {get; set;}

        public int Menu_Id { get; set; }
        [ForeignKey("Menu_Id")]
        public virtual SMenus Menu { get; set; }

    }

    public enum Tipo { Item = 1, Subitem}
}
