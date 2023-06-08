using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changedAttirbuteCarModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandID",
                table: "Models");

            migrationBuilder.RenameColumn(
                name: "BrandID",
                table: "Models",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Models_BrandID",
                table: "Models",
                newName: "IX_Models_BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Models",
                newName: "BrandID");

            migrationBuilder.RenameIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                newName: "IX_Models_BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandID",
                table: "Models",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
