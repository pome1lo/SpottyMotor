namespace CarWebApi.Models
{
    public class Car
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string CarName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Category Category { get; set; } = null!;
        public Characteristics Characteristics { get; set; } = null!;
    }
}
