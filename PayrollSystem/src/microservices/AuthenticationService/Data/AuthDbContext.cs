using Microsoft.EntityFrameworkCore;
using PayrollSystem.src.microservices.AuthenticationService.Models;

namespace PayrollSystem.src.microservices.AuthenticationService.Data
{
    public class AuthDbContext
    {
        public class AuthDbContextData : DbContext
        {
            public AuthDbContextData(DbContextOptions<AuthDbContextData> options) : base(options) { }

            public DbSet<User> Userdb { get; set; } = null!;
            public DbSet<UserRole> UserRoledb { get; set; } = null!;

            //protected override void OnModelCreating(ModelBuilder modelBuilder)
            //{
            //    modelBuilder.Entity<User>(entity =>
            //    {
            //        entity.HasKey(u => u.UserId);
            //        entity.Property(u => u.Username).HasMaxLength(50).IsRequired();
            //        entity.Property(u => u.PasswordHash).IsRequired();
            //        entity.HasIndex(u => u.Username).IsUnique();

            //        entity.HasOne(u => u.Role)
            //            .WithMany()
            //            .HasForeignKey(u => u.RoleId)
            //            .OnDelete(DeleteBehavior.Restrict);
            //    });

            //    modelBuilder.Entity<UserRole>(entity =>
            //    {
            //        entity.HasKey(r => r.RoleId);
            //        entity.Property(r => r.RoleName).HasMaxLength(50).IsRequired();
            //    });
            //}
        }
    }
}
