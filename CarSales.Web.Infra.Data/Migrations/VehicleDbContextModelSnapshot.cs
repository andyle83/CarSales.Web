﻿// <auto-generated />
using System;
using CarSales.Web.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarSales.Web.Infra.Data.Migrations
{
    [DbContext(typeof(VehicleDbContext))]
    partial class VehicleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("CarSales.Web.Domain.Models.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ExpiredUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("RegisteredUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("CarSales.Web.Domain.Models.VehicleAttribute", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Units")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Value")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleAttribute");
                });

            modelBuilder.Entity("CarSales.Web.Domain.Models.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("VehicleTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "Car",
                            Name = "Car"
                        },
                        new
                        {
                            Id = 2,
                            Code = "Bike",
                            Name = "Bike"
                        },
                        new
                        {
                            Id = 3,
                            Code = "Boat",
                            Name = "Boat"
                        },
                        new
                        {
                            Id = 4,
                            Code = "Truck",
                            Name = "Truck"
                        },
                        new
                        {
                            Id = 5,
                            Code = "Caravan",
                            Name = "Caravan"
                        });
                });

            modelBuilder.Entity("CarSales.Web.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Doors")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RegistrationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Wheels")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RegistrationId");

                    b.HasIndex("TypeId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Doors = 4,
                            Make = "Honda",
                            Model = "Hyundai i30",
                            TypeId = 1,
                            Wheels = 4
                        },
                        new
                        {
                            Id = 2,
                            Doors = 4,
                            Make = "Hyundai / Kia",
                            Model = "Toyota Hilux",
                            TypeId = 1,
                            Wheels = 4
                        },
                        new
                        {
                            Id = 3,
                            Doors = 4,
                            Make = "FCA",
                            Model = "Toyota Corolla",
                            TypeId = 1,
                            Wheels = 4
                        },
                        new
                        {
                            Id = 4,
                            Doors = 4,
                            Make = "Hyundai / Kia",
                            Model = "Toyota Hilux",
                            TypeId = 1,
                            Wheels = 4
                        },
                        new
                        {
                            Id = 5,
                            Doors = 4,
                            Make = "Honda",
                            Model = "Toyota Hilux",
                            TypeId = 1,
                            Wheels = 4
                        },
                        new
                        {
                            Id = 6,
                            Doors = 4,
                            Make = "Toyota",
                            Model = "Toyota Hilux",
                            TypeId = 1,
                            Wheels = 4
                        },
                        new
                        {
                            Id = 7,
                            Doors = 4,
                            Make = "Ford",
                            Model = "Hyundai i30",
                            TypeId = 1,
                            Wheels = 4
                        },
                        new
                        {
                            Id = 8,
                            Doors = 4,
                            Make = "Renault",
                            Model = "Toyota Corolla",
                            TypeId = 1,
                            Wheels = 4
                        },
                        new
                        {
                            Id = 9,
                            Doors = 4,
                            Make = "Toyota",
                            Model = "Toyota Corolla",
                            TypeId = 1,
                            Wheels = 4
                        },
                        new
                        {
                            Id = 10,
                            Doors = 4,
                            Make = "Volkswagen Group",
                            Model = "Hyundai Tucson",
                            TypeId = 1,
                            Wheels = 4
                        });
                });

            modelBuilder.Entity("CarSales.Web.Domain.Models.VehicleAttribute", b =>
                {
                    b.HasOne("CarSales.Web.Models.Vehicle", null)
                        .WithMany("Attributes")
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("CarSales.Web.Models.Vehicle", b =>
                {
                    b.HasOne("CarSales.Web.Domain.Models.Registration", "Registration")
                        .WithMany()
                        .HasForeignKey("RegistrationId");

                    b.HasOne("CarSales.Web.Domain.Models.VehicleType", "Type")
                        .WithMany("Vehicles")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
