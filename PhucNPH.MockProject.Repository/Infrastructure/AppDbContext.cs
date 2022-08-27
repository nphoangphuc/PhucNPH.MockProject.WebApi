using Microsoft.EntityFrameworkCore;
using PhucNPH.MockProject.Domain.Entities;
using PhucNPH.MockProject.Repository.Infrastructure.Configuration;

namespace PhucNPH.MockProject.Repository.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobDetail> JobDetails { get; set; }
        public DbSet<Department> Departments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());   
            modelBuilder.ApplyConfiguration(new JobDetailConfiguration());   
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());   
        }
    }
}
