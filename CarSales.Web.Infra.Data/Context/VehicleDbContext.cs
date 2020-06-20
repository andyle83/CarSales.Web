using CarSales.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSales.Web.Infra.Data.Context
{
    public class VehicleDbContext : DbContext
    {
        private static readonly string[] Makes = new[]
        {
            "Toyota", "Volkswagen Group", "Hyundai / Kia", "General Motors", "Ford", "Nissan", "Honda", "FCA", "Renault", "Group PSA"
        };

        private static readonly string[] Models = new[]
        {
            "Toyota Hilux", "Ford Ranger", "Hyundai i30", "Hyundai Tucson", "Toyota Corolla"
        };

        public DbSet<Vehicle> Vehicles { get; set; }

        public VehicleDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=carsales.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region VehicleSeed

            var rng = new Random();
            IEnumerable<Vehicle> vehicles = Enumerable.Range(1, 10).Select(index => new Vehicle
            {
                VehicleId = index,
                Doors = 4,
                Wheels = 4,
                Model = Models[rng.Next(Models.Length)],
                Make = Makes[rng.Next(Makes.Length)]
            })
            .ToArray();

            foreach (Vehicle vehicle in vehicles)
            {
                modelBuilder.Entity<Vehicle>().HasData(vehicle);
            }

            #endregion VehicleSeed
        }
    }
}