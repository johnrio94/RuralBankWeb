using RuralBankWeb.Data;
using RuralBankWeb.Models;

namespace RuralBankWeb.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly AppDbContext _db;
        private readonly string _uploadsFolder;

        public JobApplicationService(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _uploadsFolder = Path.Combine(env.ContentRootPath, "App_Data", "Resumes");
            Directory.CreateDirectory(_uploadsFolder);
        }

        public List<JobApplication> GetAll() =>
            _db.JobApplications.OrderByDescending(a => a.DateApplied).ToList();

        public List<JobApplication> GetByJobId(int jobId) =>
            _db.JobApplications.Where(a => a.JobId == jobId).OrderByDescending(a => a.DateApplied).ToList();

        public void Save(JobApplication application, IFormFile resume)
        {
            application.DateApplied = DateTime.Now;

            if (resume != null && resume.Length > 0)
            {
                var ext = Path.GetExtension(resume.FileName);
                var storedName = $"{Guid.NewGuid()}{ext}";
                var fullPath = Path.Combine(_uploadsFolder, storedName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    resume.CopyTo(stream);
                }

                application.ResumeFileName = resume.FileName;
                application.ResumeStoredPath = storedName;
            }

            _db.JobApplications.Add(application);
            _db.SaveChanges();
        }
    }
}