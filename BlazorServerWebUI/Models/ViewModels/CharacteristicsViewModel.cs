using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorServerWebUI.Models.ViewModels
{
    public class CharacteristicsViewModel
    {
        public int Id { get; set; }
        public int Mileage { get; set; }
        public int YearReleased { get; set; }
        public string InteriorColor { get; set; } = string.Empty;
        public CarBodyViewModel CarBody { get; set; } = null!;
        public TransmissionViewModel Transmission { get; set; } = null!;
    }
}
