using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RuralBankWeb.Models;
using RuralBankWeb.Services;

namespace RuralBankWeb.Pages.Admin.Vehicles
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IVehicleService _vehicleService;
        public IndexModel(IVehicleService vehicleService) => _vehicleService = vehicleService;

        public List<Vehicle> Vehicles { get; set; } = new();

        public void OnGet()
        {
            Vehicles = _vehicleService.GetAll();
        }

        public IActionResult OnPostDelete(int id)
        {
            _vehicleService.Delete(id);
            return RedirectToPage();
        }

        public IActionResult OnPostToggleActive(int id)
        {
            var vehicle = _vehicleService.GetById(id);
            if (vehicle != null)
            {
                vehicle.IsActive = !vehicle.IsActive;
                _vehicleService.Save(vehicle);
            }
            return RedirectToPage();
        }
    }
}