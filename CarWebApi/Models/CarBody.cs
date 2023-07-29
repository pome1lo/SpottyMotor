using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWebApi.Models
{
    [Table("car_body")]
    public class CarBody
    {
        [Key]
        [Column("car_body_id")]
        public int Id { get; set; }

        [Column("car_body_name")]
        public string CarBodyName { get; set; } = string.Empty;
    }
}