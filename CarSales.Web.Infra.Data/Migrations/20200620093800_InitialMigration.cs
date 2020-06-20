using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSales.Web.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Doors = table.Column<int>(nullable: false),
                    Wheels = table.Column<int>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Doors", "Make", "Model", "Wheels" },
                values: new object[] { 1, 4, "Hyundai / Kia", "Toyota Hilux", 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Doors", "Make", "Model", "Wheels" },
                values: new object[] { 2, 4, "Group PSA", "Hyundai Tucson", 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Doors", "Make", "Model", "Wheels" },
                values: new object[] { 3, 4, "Group PSA", "Toyota Hilux", 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Doors", "Make", "Model", "Wheels" },
                values: new object[] { 4, 4, "Nissan", "Ford Ranger", 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Doors", "Make", "Model", "Wheels" },
                values: new object[] { 5, 4, "FCA", "Ford Ranger", 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Doors", "Make", "Model", "Wheels" },
                values: new object[] { 6, 4, "Nissan", "Toyota Corolla", 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Doors", "Make", "Model", "Wheels" },
                values: new object[] { 7, 4, "FCA", "Toyota Corolla", 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Doors", "Make", "Model", "Wheels" },
                values: new object[] { 8, 4, "Group PSA", "Hyundai i30", 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Doors", "Make", "Model", "Wheels" },
                values: new object[] { 9, 4, "Nissan", "Hyundai Tucson", 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Doors", "Make", "Model", "Wheels" },
                values: new object[] { 10, 4, "General Motors", "Toyota Hilux", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
