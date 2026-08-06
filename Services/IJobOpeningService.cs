using RuralBankWeb.Models;

namespace RuralBankWeb.Services
{
    public interface IJobOpeningService
    {
        List<JobOpening> GetAll();
        List<JobOpening> GetActive();
        JobOpening? GetById(int id);
        void Save(JobOpening job);
        void Delete(int id);
    }
}