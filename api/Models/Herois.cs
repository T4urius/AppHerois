using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("herois")]
    public class Herois
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }

        [Column("nomeheroi")]
        public string? NomeHeroi { get; set; }

        [Column("datanascimento")]
        public DateTime DataNascimento { get; set; } 

        [Column("altura")]
        public float Altura { get; set; }

        [Column("peso")]
        public float Peso { get; set; }

        [NotMapped]
        public int? Idsuperpoder { get; set; }
    }
}
