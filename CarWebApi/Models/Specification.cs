using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWebApi.Models
{
    [Table("specifications")]
    public class Specification
    {
        [Key]
        [Column("specification_id")]
        public int Id { get; set; }

        [Column("specification_engine")]
        public List<string> Engine { get; set; } = null!;

        [Column("specification_dimensions")]
        public List<string> Dimensions { get; set; } = null!;

        [Column("specification_characteristics")]
        public List<string> OperationalCharacteristics { get; set; } = null!;

        [Column("specification_factory_options")]
        public List<string> FactoryOptions { get; set; } = null!;

        [Column("specification_advantages")]
        public List<string> Advantages { get; set; } = null!;
    }
}