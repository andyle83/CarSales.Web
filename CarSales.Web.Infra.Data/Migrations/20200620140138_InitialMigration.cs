using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSales.Web.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    State = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    ExpiredUtc = table.Column<DateTime>(nullable: true),
                    RegisteredUtc = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Doors = table.Column<int>(nullable: false),
                    Wheels = table.Column<int>(nullable: false),
                    Make = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    RegistrationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Registration_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleAttribute",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    Units = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleAttribute_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 1, "Car", "Car" });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 2, "Bike", "Bike" });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 3, "Boat", "Boat" });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 4, "Truck", "Truck" });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 5, "Caravan", "Caravan" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Description", "Doors", "Make", "Model", "RegistrationId", "TypeId", "Wheels" },
                values: new object[] { 1, null, 4, "Volkswagen Group", "Ford Ranger", null, 1, 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Description", "Doors", "Make", "Model", "RegistrationId", "TypeId", "Wheels" },
                values: new object[] { 2, null, 4, "General Motors", "Hyundai i30", null, 1, 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Description", "Doors", "Make", "Model", "RegistrationId", "TypeId", "Wheels" },
                values: new object[] { 3, null, 4, "Toyota", "Ford Ranger", null, 1, 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Description", "Doors", "Make", "Model", "RegistrationId", "TypeId", "Wheels" },
                values: new object[] { 4, null, 4, "Hyundai / Kia", "Toyota Hilux", null, 1, 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Description", "Doors", "Make", "Model", "RegistrationId", "TypeId", "Wheels" },
                values: new object[] { 5, null, 4, "General Motors", "Ford Ranger", null, 1, 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Description", "Doors", "Make", "Model", "RegistrationId", "TypeId", "Wheels" },
                values: new object[] { 6, null, 4, "General Motors", "Hyundai i30", null, 1, 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Description", "Doors", "Make", "Model", "RegistrationId", "TypeId", "Wheels" },
                values: new object[] { 7, null, 4, "Group PSA", "Ford Ranger", null, 1, 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Description", "Doors", "Make", "Model", "RegistrationId", "TypeId", "Wheels" },
                values: new object[] { 8, null, 4, "General Motors", "Hyundai Tucson", null, 1, 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Description", "Doors", "Make", "Model", "RegistrationId", "TypeId", "Wheels" },
                values: new object[] { 9, null, 4, "Renault", "Toyota Corolla", null, 1, 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Description", "Doors", "Make", "Model", "RegistrationId", "TypeId", "Wheels" },
                values: new object[] { 10, null, 4, "Honda", "Hyundai i30", null, 1, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleAttribute_VehicleId",
                table: "VehicleAttribute",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_RegistrationId",
                table: "Vehicles",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TypeId",
                table: "Vehicles",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleAttribute");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}
