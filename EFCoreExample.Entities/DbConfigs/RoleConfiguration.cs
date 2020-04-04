using EFCoreExample.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreExample.Entities.DbConfigs
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName(nameof(Role.Id)).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName(nameof(Role.Name)).HasColumnType("nvarchar(256)").IsRequired().HasMaxLength(256);
            builder.Property(x => x.NormalizedName).HasColumnName(nameof(Role.NormalizedName)).HasColumnType("nvarchar(256)").IsRequired(false).HasMaxLength(256);
            builder.Property(x => x.ConcurrencyStamp).HasColumnName(nameof(Role.ConcurrencyStamp)).HasColumnType("nvarchar(max)").IsRequired(false);

            builder.HasMany(x => x.UserRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}