using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NMMSystem.Data.Domein.Migrations
{
    public partial class rec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupplierRecomendators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecommenderSupplierId = table.Column<int>(type: "int", nullable: false),
                    RecommendedSupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierRecomendators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierRecomendators_Supplier_RecommendedSupplierId",
                        column: x => x.RecommendedSupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupplierRecomendators_Supplier_RecommenderSupplierId",
                        column: x => x.RecommenderSupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierRecomendators_RecommendedSupplierId",
                table: "SupplierRecomendators",
                column: "RecommendedSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierRecomendators_RecommenderSupplierId",
                table: "SupplierRecomendators",
                column: "RecommenderSupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplierRecomendators");
        }
    }
}
