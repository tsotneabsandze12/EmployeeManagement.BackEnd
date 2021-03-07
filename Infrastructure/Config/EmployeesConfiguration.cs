using System;
using Core.Entities;
using Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class EmployeesConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(p => p.PersonalId)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(p => p.FirstName)
                .HasColumnType("nvarchar(50)").IsRequired();

            builder.Property(p => p.LastName)
                .HasColumnType("nvarchar(50)").IsRequired();

            builder.Property(p => p.Gender)
                .HasConversion(
                    x => x.ToString(),
                    x => (GenderEnum) Enum.Parse(typeof(GenderEnum), x))
                .HasColumnType("nvarchar(10)")
                .IsRequired();

            builder.Property(p => p.BirthDate).HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.Status)
                .HasConversion(
                    x => x.ToString(),
                    x => (StatusEnum) Enum.Parse(typeof(StatusEnum), x))
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(p => p.DateReleased).HasColumnType("date");

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(9)
                .IsRequired();

            builder.HasOne(p => p.Position)
                .WithMany().HasForeignKey(k => k.PositionId);

            builder.HasIndex(p => p.PersonalId).IsUnique();
            builder.HasIndex(p => p.PhoneNumber).IsUnique();
        }
    }
}