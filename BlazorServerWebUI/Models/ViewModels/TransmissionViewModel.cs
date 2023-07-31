using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerWebUI.Models.ViewModels
{
    public class TransmissionViewModel
    {
        public int Id { get; set; }
        public string TransmissionName { get; set; } = string.Empty;
    }
}
