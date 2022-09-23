using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NMMSystem.Data.Domein.Migrations
{
    public partial class SupplierBonusSpecificTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupplierBonusSpecificTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Bonus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateTimeFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierBonusSpecificTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierBonusSpecificTime_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierBonusSpecificTime_SupplierId",
                table: "SupplierBonusSpecificTime",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplierBonusSpecificTime");
        }
    }
}
