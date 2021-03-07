using System;
using System.Collections.Generic;
using Core.Entities;
using Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
   public static class SeedDataExtensionMethods
    {
        public static void SeedPositions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(
                new List<Position>
                {
                    new Position
                    {
                        Id = 1,
                        Name = "Developer"
                    },
                    new Position
                    {
                        Id=2,
                        Name = "HR",
                    },
                    new Position
                    {
                        Id = 3,
                        Name = "Designer"
                    }
                });
        }
        
        public static void SeedEmployees(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new List<Employee>
                {
                   new Employee
                   {
                       Id = 1,
                       PersonalId = "19001304662",
                       FirstName = "John",
                       LastName = "Doe",
                       Gender = GenderEnum.Male,
                       BirthDate = new DateTime(1990,4,22),
                       Status = StatusEnum.Regular,
                       PhoneNumber = "941293812",
                       PositionId = 1
                   },
                   new Employee
                   {
                       Id = 2,
                       PersonalId = "18001304662",
                       FirstName = "Grisha",
                       LastName = "Oniani",
                       Gender = GenderEnum.Male,
                       BirthDate = new DateTime(1890,2,22),
                       Status = StatusEnum.NonRegular,
                       PhoneNumber = "911293812",
                       PositionId = 3
                   },
                   new Employee
                   {
                       Id = 3,
                       PersonalId = "18071304662",
                       FirstName = "Badri",
                       LastName = "Shubladze",
                       Gender = GenderEnum.Male,
                       BirthDate = new DateTime(1690,9,17),
                       Status = StatusEnum.Released,
                       DateReleased = DateTime.Today,
                       PhoneNumber = "941293312",
                       PositionId = 1
                   },
                   new Employee
                   {
                       Id = 4,
                       PersonalId = "18071304772",
                       FirstName = "Greta",
                       LastName = "Thunberg",
                       Gender = GenderEnum.Female,
                       BirthDate = new DateTime(2018,11,2),
                       Status = StatusEnum.Released,
                       DateReleased = DateTime.Today,
                       PhoneNumber = "941290312",
                       PositionId = 3
                   },
                   new Employee
                   {
                       Id = 5,
                       PersonalId = "18071304102",
                       FirstName = "C",
                       LastName = "Sharp",
                       Gender = GenderEnum.Male,
                       BirthDate = new DateTime(2008,2,2),
                       Status = StatusEnum.Regular,
                       PhoneNumber = "941294312",
                       PositionId = 1
                   },
                });
        }
    }
}