namespace CarWebApi.Models
{
    public class Characteristics
    {
        public int Id { get; set; }
        public int Mileage { get; set; }
        public int YearReleased { get; set; }
        public CarBody CarBody { get; set; } = null!;
        public Transmission Transmission { get; set; } = null!;
        public string InteriorColor{ get; set; } = string.Empty;
    }
}