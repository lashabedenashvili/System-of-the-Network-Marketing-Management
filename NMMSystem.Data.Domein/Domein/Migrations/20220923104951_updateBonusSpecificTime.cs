using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NMMSystem.Data.Domein.Migrations
{
    public partial class updateBonusSpecificTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SupplierBonusSpecificTime",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "SupplierBonusSpecificTime",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SupplierBonusSpecificTime");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "SupplierBonusSpecificTime");
        }
    }
}
