using Microsoft.EntityFrameworkCore;
using QTect.Models;

namespace QTect.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<PerformanceReview> PerformanceReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentID);

            modelBuilder.Entity<Department>()
                   .HasOne(d => d.Manager)
                   .WithMany(e => e.ManagedDepartments) 
                   .HasForeignKey(d => d.ManagerID)
                   .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PerformanceReview>()
                .HasOne(pr => pr.Employee)
                .WithMany(e => e.PerformanceReviews)
                .HasForeignKey(pr => pr.EmployeeID);

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Name);

            modelBuilder.Entity<PerformanceReview>()
                .HasIndex(pr => pr.ReviewScore);
        }
    }
}
