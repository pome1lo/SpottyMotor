using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarWebApi.Models
{
    [Table("transmission")]
    public class Transmission
    {
        [Key]
        [Column("transmission_id")]
        public int Id { get; set; }

        [Column("transmission_name")]
        public string TransmissionName { get; set; } = string.Empty;
    }
}