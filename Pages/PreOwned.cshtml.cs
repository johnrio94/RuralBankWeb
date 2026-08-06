using Microsoft.AspNetCore.Mvc.RazorPages;
using RuralBankWeb.Models;
using RuralBankWeb.Services;

namespace RuralBankWeb.Pages
{
    public class PreOwnedModel : PageModel
    {
        private readonly IVehicleService _vehicleService;
        public PreOwnedModel(IVehicleService vehicleService) => _vehicleService = vehicleService;

        public List<Vehicle> Vehicles { get; set; } = new();

        public void OnGet()
        {
            Vehicles = _vehicleService.GetActive();
        }
    }
}