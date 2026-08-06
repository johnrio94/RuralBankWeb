using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RuralBankWeb.Models;
using RuralBankWeb.Services;

namespace RuralBankWeb.Pages.Admin.Properties
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IPropertyService _propertyService;
        public IndexModel(IPropertyService propertyService) => _propertyService = propertyService;

        public List<Property> Properties { get; set; } = new();

        public void OnGet()
        {
            Properties = _propertyService.GetAll();
        }

        public IActionResult OnPostDelete(int id)
        {
            _propertyService.Delete(id);
            return RedirectToPage();
        }

        public IActionResult OnPostToggleActive(int id)
        {
            var property = _propertyService.GetById(id);
            if (property != null)
            {
                property.IsActive = !property.IsActive;
                _propertyService.Save(property);
            }
            return RedirectToPage();
        }
    }
}