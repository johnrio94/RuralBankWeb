// using Microsoft.EntityFrameworkCore;
// using RuralBankWeb.Models;

// namespace RuralBankWeb.Data
// {
//     public class AppDbContext : DbContext
//     {
//         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

//         public DbSet<JobOpening> JobOpenings { get; set; } = null!;
//         public DbSet<JobApplication> JobApplications { get; set; } = null!;
//     }
// }


using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RuralBankWeb.Models;

namespace RuralBankWeb.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<JobOpening> JobOpenings { get; set; } = null!;
        public DbSet<JobApplication> JobApplications { get; set; } = null!;
        public DbSet<PageSection> PageSections { get; set; } = null!;

        public DbSet<Property> Properties { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // REQUIRED for Identity tables
        }
    }
}