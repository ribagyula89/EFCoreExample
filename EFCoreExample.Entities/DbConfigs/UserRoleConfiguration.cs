using EFCoreExample.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreExample.Entities.DbConfigs
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable(nameof(UserRole));
            builder.HasKey(x => new { x.UserId, x.RoleId });

            builder.Property(x => x.UserId).HasColumnName(nameof(UserRole.UserId)).HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.RoleId).HasColumnName(nameof(UserRole.RoleId)).HasColumnType("int").IsRequired().ValueGeneratedNever();

            builder.HasOne(a => a.Role).WithMany(b => b.UserRoles).HasForeignKey(c => c.RoleId);
            builder.HasOne(a => a.User).WithMany(b => b.UserRoles).HasForeignKey(c => c.UserId);
        }
    }
}