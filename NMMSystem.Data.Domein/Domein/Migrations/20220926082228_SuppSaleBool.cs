using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NMMSystem.Data.Domein.Migrations
{
    public partial class SuppSaleBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimePeriodBool",
                table: "SupplierBonusSpecificTime");

            migrationBuilder.AddColumn<bool>(
                name: "Counted",
                table: "SupplierSale",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Counted",
                table: "SupplierSale");

            migrationBuilder.AddColumn<bool>(
                name: "TimePeriodBool",
                table: "SupplierBonusSpecificTime",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
