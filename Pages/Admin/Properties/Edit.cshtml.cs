using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RuralBankWeb.Models;
using RuralBankWeb.Services;

namespace RuralBankWeb.Pages.Admin.Properties
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IPropertyService _propertyService;
        public EditModel(IPropertyService propertyService) => _propertyService = propertyService;

        [BindProperty]
        public Property Property { get; set; } = new();

        public void OnGet(int id = 0)
        {
            if (id != 0)
            {
                var existing = _propertyService.GetById(id);
                if (existing != null) Property = existing;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _propertyService.Save(Property);
            return RedirectToPage("Index");
        }
    }
}