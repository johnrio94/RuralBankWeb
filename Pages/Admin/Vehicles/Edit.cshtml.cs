using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RuralBankWeb.Models;
using RuralBankWeb.Services;

namespace RuralBankWeb.Pages.Admin.Vehicles
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IVehicleService _vehicleService;
        public EditModel(IVehicleService vehicleService) => _vehicleService = vehicleService;

        [BindProperty]
        public Vehicle Vehicle { get; set; } = new();

        public void OnGet(int id = 0)
        {
            if (id != 0)
            {
                var existing = _vehicleService.GetById(id);
                if (existing != null) Vehicle = existing;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _vehicleService.Save(Vehicle);
            return RedirectToPage("Index");
        }
    }
}
