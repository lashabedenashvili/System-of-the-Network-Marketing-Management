using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NMMSystem.Data.Domein.Migrations
{
    public partial class SupplierBonusSpecifiTimeTypeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TimePeriodBool",
                table: "SupplierBonusSpecificTime",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimePeriodBool",
                table: "SupplierBonusSpecificTime");
        }
    }
}
