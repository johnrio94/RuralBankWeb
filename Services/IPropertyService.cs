using RuralBankWeb.Models;

namespace RuralBankWeb.Services
{
    public interface IPropertyService
    {
        List<Property> GetAll();
        List<Property> GetActive();
        Property? GetById(int id);
        void Save(Property property);
        void Delete(int id);
    }
}