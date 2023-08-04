namespace BlazorServerWebUI.Models.ViewModels
{
    public class SpecificationItemViewModel
    {
        public string IdName { get; set; } = string.Empty;
        public string Heading { get; set; } = string.Empty;
        public List<string> List { get; set; } = null!;

        public SpecificationItemViewModel(string idName, string heading, List<string> list)
        {
            List = list;
            IdName = idName;
            Heading = heading;
        }
    }
}
