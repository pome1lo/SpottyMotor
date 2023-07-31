namespace BlazorServerWebUI.Models.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string CarName { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public CategoryViewModel CategoryName { get; set; } = null!;
        public CharacteristicsViewModel Characteristics { get; set; } = null!;
    }
}
