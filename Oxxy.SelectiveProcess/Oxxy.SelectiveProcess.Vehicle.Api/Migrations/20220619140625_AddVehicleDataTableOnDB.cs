using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oxxy.SelectiveProcess.Vehicle.Api.Migrations
{
    public partial class AddVehicleDataTableOnDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    license_plate = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    license = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    owner_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    owner_cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
