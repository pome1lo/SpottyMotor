using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWebApi.Models
{
    [Table("car")]
    public class Car
    {
        [Key]
        [Column("car_id")]
        public int Id { get; set; }

        [Column("car_price")]
        public decimal Price { get; set; }

        [Column("car_name")]
        public string CarName { get; set; } = string.Empty;

        [Column("car_description")]
        public string Description { get; set; } = string.Empty;

        [Column("car_category_id")]
        public int CategoryId { get; set; }

        [Column("car_category")]
        public Category Category { get; set; } = null!;

        [Column("car_characteristics_id")]
        public int CharacteristicsId { get; set; }

        [Column("car_characteristics")]
        public Characteristics Characteristics { get; set; } = null!;
    }
}
