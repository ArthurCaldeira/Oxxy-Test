using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oxxy.SelectiveProcess.VehicleImage.Api.Migrations
{
    public partial class AddVehicleImageDataTableOnDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleImages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vehicle_id = table.Column<int>(type: "int", nullable: false),
                    image_data = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleImages", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleImages");
        }
    }
}
