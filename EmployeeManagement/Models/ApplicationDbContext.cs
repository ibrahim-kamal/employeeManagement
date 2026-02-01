using EmployeeManagement.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace EmployeeManagement.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<IdentityUserClaim<string>> identityUserClaims { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("user");
            modelBuilder.Entity<IdentityRole>().ToTable("role");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("userRole");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("userClaim");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("userLogin");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("roleClaim");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("usertoken");
        }



    }
}
