using Microsoft.EntityFrameworkCore;
using MyProject.Shared;

namespace MyProject.Server.CRUD
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<AssessmentInfo> AssessmentInfos { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
