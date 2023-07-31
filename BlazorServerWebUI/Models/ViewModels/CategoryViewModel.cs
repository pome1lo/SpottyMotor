using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerWebUI.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
