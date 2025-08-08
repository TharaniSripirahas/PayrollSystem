using Microsoft.EntityFrameworkCore;
using PayrollSystem.src.microservices.AuthenticationService.Models;
using PayrollSystem.src.microservices.Employee.Models;

namespace PayrollSystem.src.microservices.Shared.Data
{
    public class PayrollDbContext : DbContext
    {
        public PayrollDbContext(DbContextOptions<PayrollDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<UserRole> UserRoles { get; set; } = null!;

        public DbSet<Employees> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employees>()
                        .Ignore(e => e.UserRoles);
        }
    }
}
