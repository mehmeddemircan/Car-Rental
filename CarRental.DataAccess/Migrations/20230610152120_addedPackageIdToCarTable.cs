using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedPackageIdToCarTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PackageId",
                table: "Cars",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Packages_PackageId",
                table: "Cars",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Packages_PackageId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_PackageId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Cars");
        }
    }
}
