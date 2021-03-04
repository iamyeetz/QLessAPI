using Microsoft.EntityFrameworkCore.Migrations;

namespace QLessAPI.Migrations
{
    public partial class UpdatedTablesTransport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromStationId",
                table: "Transport");

            migrationBuilder.DropColumn(
                name: "ToStationId",
                table: "Transport");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FromStationId",
                table: "Transport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToStationId",
                table: "Transport",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
