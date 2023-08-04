namespace BlazorServerWebUI.Models.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string CarName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Images { get; set; } = null!;
        public CategoryViewModel CategoryName { get; set; } = null!;
        public SpecificationViewModel Specification { get; set; } = null!;
        public CharacteristicsViewModel Characteristics { get; set; } = null!;
    }
}
