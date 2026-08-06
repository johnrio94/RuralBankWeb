using RuralBankWeb.Models;

namespace RuralBankWeb.Services
{
    public interface IVehicleService
    {
        List<Vehicle> GetAll();
        List<Vehicle> GetActive();
        Vehicle? GetById(int id);
        void Save(Vehicle vehicle);
        void Delete(int id);
    }
}