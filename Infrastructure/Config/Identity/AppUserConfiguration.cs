using System;
using Core.Entities.Identity;
using Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config.Identity
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(p => p.PersonalId).HasMaxLength(11)
                .IsRequired();

            builder.Property(p => p.FirstName).HasColumnType("nvarchar(30)")
                .IsRequired();

            builder.Property(p => p.LastName).HasColumnType("nvarchar(30)")
                .IsRequired();

            builder.Property(p => p.Gender)
                .HasConversion(
                    x => x.ToString(),
                    x => (GenderEnum) Enum.Parse(typeof(GenderEnum), x))
                .HasColumnType("nvarchar(10)")
                .IsRequired();

            builder.Property(p => p.BirthDate).HasColumnType("date")
                .IsRequired();
        }
    }
}