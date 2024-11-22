using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("super_poderes")]
    public class Superpoderes
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("superpoder")]
        public string? Superpoder { get; set; }

        [Column("descricao")]
        public string? Descricao { get; set; }
    }
}
