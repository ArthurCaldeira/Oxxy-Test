using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oxxy.SelectiveProcess.Vehicle.Api.Migrations
{
    public partial class AddVehicleDataTableOnDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_locked",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_locked",
                table: "Vehicles");
        }
    }
}
