using System.Linq;
using System.Reflection;
using Core.Entities;
using Core.Entities.Identity;
using Infrastructure.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(),
                type => type == typeof(EmployeesConfiguration) || type == typeof(PositionConfiguration));
           // Assembly.GetExecutingAssembly()
            
            modelBuilder.SeedPositions();
            modelBuilder.SeedEmployees();
        }
    }
}