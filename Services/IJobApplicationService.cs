using RuralBankWeb.Models;

namespace RuralBankWeb.Services
{
    public interface IJobApplicationService
    {
        List<JobApplication> GetAll();
        List<JobApplication> GetByJobId(int jobId);
        void Save(JobApplication application, IFormFile resume);
    }
}