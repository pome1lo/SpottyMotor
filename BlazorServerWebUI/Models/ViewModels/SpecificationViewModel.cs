namespace BlazorServerWebUI.Models.ViewModels
{
    public class SpecificationViewModel
    {
        public int Id { get; set; }
        public List<string> Engine { get; set; } = null!;
        public List<string> Dimensions { get; set; } = null!;
        public List<string> OperationalCharacteristics { get; set; } = null!;
        public List<string> FactoryOptions { get; set; } = null!;
        public List<string> Advantages { get; set; } = null!;
    }
}
