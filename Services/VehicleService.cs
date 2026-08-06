using RuralBankWeb.Data;
using RuralBankWeb.Models;

namespace RuralBankWeb.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly AppDbContext _db;
        public VehicleService(AppDbContext db) => _db = db;

        public List<Vehicle> GetAll() =>
            _db.Vehicles.OrderBy(v => v.SortOrder).ThenByDescending(v => v.DateAdded).ToList();

        public List<Vehicle> GetActive() =>
            _db.Vehicles.Where(v => v.IsActive).OrderBy(v => v.SortOrder).ThenByDescending(v => v.DateAdded).ToList();

        public Vehicle? GetById(int id) =>
            _db.Vehicles.Find(id);

        public void Save(Vehicle vehicle)
        {
            if (vehicle.Id == 0)
            {
                vehicle.DateAdded = DateTime.Now;
                vehicle.UnitId = GenerateNextUnitId();
                _db.Vehicles.Add(vehicle);
            }
            else
            {
                _db.Vehicles.Update(vehicle);
            }
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var vehicle = _db.Vehicles.Find(id);
            if (vehicle != null)
            {
                _db.Vehicles.Remove(vehicle);
                _db.SaveChanges();
            }
        }

        private string GenerateNextUnitId()
        {
            var existingNumbers = _db.Vehicles
                .Select(v => v.UnitId)
                .ToList()
                .Where(id => !string.IsNullOrEmpty(id) && id.StartsWith("RBN-AUTO-"))
                .Select(id =>
                {
                    var numPart = id!.Replace("RBN-AUTO-", "");
                    return int.TryParse(numPart, out var n) ? n : 0;
                })
                .ToList();

            int nextNumber = existingNumbers.Any() ? existingNumbers.Max() + 1 : 1;
            return $"RBN-AUTO-{nextNumber:D3}";
        }
    }
}