using EFCoreExample.Core.Models;
using EFCoreExample.Entities.DbConfigs;
using EFCoreExample.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreExample.Entities
{
    public class ApplicationDbContext : IdentityDbContext<
        User,
        Role,
        int,
        IdentityUserClaim<int>,
        UserRole,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            AddRoles(modelBuilder);
            AddSuperAdmin(modelBuilder);
        }

        private void AddRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(new Role()
                {
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Id = 1,
                    Name = nameof(RoleType.SuperAdmin),
                    NormalizedName = nameof(RoleType.SuperAdmin).ToUpper()
                });


            modelBuilder.Entity<Role>()
                .HasData(new Role()
                {
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Id = 2,
                    Name = nameof(RoleType.Admin),
                    NormalizedName = nameof(RoleType.Admin).ToUpper()
                });


            modelBuilder.Entity<Role>()
                .HasData(new Role()
                {
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Id = 3,
                    Name = nameof(RoleType.ConfirmedUser),
                    NormalizedName = nameof(RoleType.ConfirmedUser).ToUpper()
                });
        }

        private void AddSuperAdmin(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new User()
                {
                    AccessFailedCount = 0,
                    Email = "mail@mail.com",
                    EmailConfirmed = true,
                    FirstName = "Admin",
                    Id = 1,
                    LastName = "Admin",
                    LockoutEnabled = false,
                    NormalizedEmail = "MAIL@MAIL.COM",
                    NormalizedUserName = "SUPERADMIN",
                    PasswordHash = "testhash==",
                    PhoneNumberConfirmed = false,
                    UserName = "Superadmin",
                    SecurityStamp = "B7ZXHVHLSRIZZUVVSJZQ37GLVOOC3FYG",
                    TwoFactorEnabled = false
                });

            modelBuilder.Entity<UserRole>()
                .HasData(new UserRole()
                {
                    RoleId = 1,
                    UserId = 1
                });
        }
    }
}