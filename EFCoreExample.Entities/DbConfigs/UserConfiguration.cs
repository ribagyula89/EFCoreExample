using EFCoreExample.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreExample.Entities.DbConfigs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName(nameof(User.Id)).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.UserName).HasColumnName(nameof(User.UserName)).HasColumnType("nvarchar(256)").IsRequired().HasMaxLength(256);
            builder.Property(x => x.FirstName).HasColumnName(nameof(User.FirstName)).HasColumnType("nvarchar(MAX)").IsRequired();
            builder.Property(x => x.LastName).HasColumnName(nameof(User.LastName)).HasColumnType("nvarchar(MAX)").IsRequired();
            builder.Property(x => x.NormalizedUserName).HasColumnName(nameof(User.NormalizedUserName)).HasColumnType("nvarchar(256)").IsRequired(false).HasMaxLength(256);
            builder.Property(x => x.Email).HasColumnName(nameof(User.Email)).HasColumnType("nvarchar(256)").IsRequired().HasMaxLength(256);
            builder.Property(x => x.NormalizedEmail).HasColumnName(nameof(User.NormalizedEmail)).HasColumnType("nvarchar(256)").IsRequired(false).HasMaxLength(256);
            builder.Property(x => x.EmailConfirmed).HasColumnName(nameof(User.EmailConfirmed)).HasColumnType("bit").IsRequired();
            builder.Property(x => x.PasswordHash).HasColumnName(nameof(User.PasswordHash)).HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.SecurityStamp).HasColumnName(nameof(User.SecurityStamp)).HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.ConcurrencyStamp).HasColumnName(nameof(User.ConcurrencyStamp)).HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.PhoneNumber).HasColumnName(nameof(User.PhoneNumber)).HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.PhoneNumberConfirmed).HasColumnName(nameof(User.PhoneNumberConfirmed)).HasColumnType("bit").IsRequired();
            builder.Property(x => x.TwoFactorEnabled).HasColumnName(nameof(User.TwoFactorEnabled)).HasColumnType("bit").IsRequired();
            builder.Property(x => x.LockoutEnd).HasColumnName(nameof(User.LockoutEnd)).HasColumnType("datetimeoffset").IsRequired(false);
            builder.Property(x => x.LockoutEnabled).HasColumnName(nameof(User.LockoutEnabled)).HasColumnType("bit").IsRequired();
            builder.Property(x => x.AccessFailedCount).HasColumnName(nameof(User.AccessFailedCount)).HasColumnType("int").IsRequired();

            builder.HasMany(x => x.UserRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}