using Microsoft.EntityFrameworkCore;
using RuralBankWeb.Data;
using RuralBankWeb.Models;

namespace RuralBankWeb.Services
{
    public class JobOpeningService : IJobOpeningService
    {

        
        private readonly AppDbContext _db;
        public JobOpeningService(AppDbContext db) => _db = db;

        public List<JobOpening> GetAll() =>
            _db.JobOpenings.OrderByDescending(j => j.DatePosted).ToList();

        public List<JobOpening> GetActive() =>
            _db.JobOpenings.Where(j => j.IsActive).OrderByDescending(j => j.DatePosted).ToList();

        public JobOpening? GetById(int id) =>
            _db.JobOpenings.Find(id);

        public void Save(JobOpening job)
        {
            if (job.Id == 0)
            {
                job.DatePosted = DateTime.Now;
                _db.JobOpenings.Add(job);
            }
            else
            {
                _db.JobOpenings.Update(job);
            }
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var job = _db.JobOpenings.Find(id);
            if (job != null)
            {
                _db.JobOpenings.Remove(job);
                _db.SaveChanges();
            }
        }
    }
}

