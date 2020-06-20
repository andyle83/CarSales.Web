using CarSales.Web.Domain.Models;
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

        public DbSet<VehicleType> VehicleTypes { get; set; }
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
            modelBuilder.Entity<VehicleType>(type =>
            {
                type.Property(e => e.Code).IsRequired();
                type.Property(e => e.Name).IsRequired();
            });

            #region VehicleTypeSeed

            modelBuilder.Entity<VehicleType>().HasData(new VehicleType { Id = 1, Code = "Car", Name = "Car" });
            modelBuilder.Entity<VehicleType>().HasData(new VehicleType { Id = 2, Code = "Bike", Name = "Bike" });
            modelBuilder.Entity<VehicleType>().HasData(new VehicleType { Id = 3, Code = "Boat", Name = "Boat" });
            modelBuilder.Entity<VehicleType>().HasData(new VehicleType { Id = 4, Code = "Truck", Name = "Truck" });
            modelBuilder.Entity<VehicleType>().HasData(new VehicleType { Id = 5, Code = "Caravan", Name = "Caravan" });

            #endregion VehicleTypeSeed

            modelBuilder.Entity<Vehicle>(vehicle =>
            {
                vehicle.Property(e => e.Model).IsRequired();
                vehicle.Property(e => e.Make).IsRequired();
            });

            modelBuilder.Entity<Vehicle>(vehicle =>
            {
                vehicle.HasOne(d => d.Type)
                    .WithMany(t => t.Vehicles)
                    .HasForeignKey("TypeId");
            });

            #region VehicleSeed

            var rng = new Random();
            IEnumerable<Vehicle> vehicles = Enumerable.Range(1, 10).Select(index => new Vehicle
            {
                Id = index,
                Doors = 4,
                Wheels = 4,
                Model = Models[rng.Next(Models.Length)],
                Make = Makes[rng.Next(Makes.Length)],
                TypeId = 1
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