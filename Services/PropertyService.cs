using RuralBankWeb.Data;
using RuralBankWeb.Models;

namespace RuralBankWeb.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly AppDbContext _db;
        public PropertyService(AppDbContext db) => _db = db;

        public List<Property> GetAll() =>
            _db.Properties.OrderBy(p => p.SortOrder).ThenByDescending(p => p.DateAdded).ToList();

        public List<Property> GetActive() =>
            _db.Properties.Where(p => p.IsActive).OrderBy(p => p.SortOrder).ThenByDescending(p => p.DateAdded).ToList();

        public Property? GetById(int id) =>
            _db.Properties.Find(id);

        public void Save(Property property)
        {
            if (property.Id == 0)
            {
                property.DateAdded = DateTime.Now;
                property.PropertyId = GenerateNextPropertyId();
                _db.Properties.Add(property);
            }
            else
            {
                _db.Properties.Update(property);
            }
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var property = _db.Properties.Find(id);
            if (property != null)
            {
                _db.Properties.Remove(property);
                _db.SaveChanges();
            }
        }

        private string GenerateNextPropertyId()
        {
            var existingNumbers = _db.Properties
                .Select(p => p.PropertyId)
                .ToList() // pull to memory since we need string parsing
                .Where(id => id.StartsWith("RBN-PROP-"))
                .Select(id =>
                {
                    var numPart = id.Replace("RBN-PROP-", "");
                    return int.TryParse(numPart, out var n) ? n : 0;
                })
                .ToList();

            int nextNumber = existingNumbers.Any() ? existingNumbers.Max() + 1 : 1;
            return $"RBN-PROP-{nextNumber:D3}"; // pads to 3 digits: 001, 002, ... 010, 100
        }
    }
}