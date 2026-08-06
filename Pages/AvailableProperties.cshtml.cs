using Microsoft.AspNetCore.Mvc.RazorPages;
using RuralBankWeb.Models;
using RuralBankWeb.Services;

namespace RuralBankWeb.Pages
{
    public class AvailablePropertiesModel : PageModel
    {
        private readonly IPropertyService _propertyService;
        public AvailablePropertiesModel(IPropertyService propertyService) => _propertyService = propertyService;

        public List<Property> Properties { get; set; } = new();

        public void OnGet()
        {
            Properties = _propertyService.GetActive();
        }
    }
}