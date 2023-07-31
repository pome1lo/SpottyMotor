using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarWebApi.Models
{
    [Table("characteristics")]
    public class Characteristics
    {
        [Key]
        [Column("characteristics_id")]
        public int Id { get; set; }

        [Column("characteristics_mileage")]
        public int Mileage { get; set; }

        [Column("characteristics_year_released")]
        public int YearReleased { get; set; }

        [Column("characteristics_interior_color")]
        public string InteriorColor { get; set; } = string.Empty;

        [Column("characteristics_car_body_id")]
        public int CarBodyId { get; set; }
        
        [Column("characteristics_car_body")]
        public CarBody CarBody { get; set; } = null!;

        [Column("characteristics_transmission_id")]
        public int TransmissionId { get; set; }

        [Column("characteristics_transmission")]
        public Transmission Transmission { get; set; } = null!;
    }
}