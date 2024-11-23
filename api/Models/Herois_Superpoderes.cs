using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("herois_superpoderes")]
    public class Herois_Superpoderes
    {
        [Key]
        [Column("heroiid")]
        public int HeroiId { get; set; }

        [Column("superpoderid")]
        public int SuperpoderId{ get; set; }
    }
}
