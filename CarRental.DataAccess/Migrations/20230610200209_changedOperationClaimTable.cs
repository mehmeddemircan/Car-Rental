using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changedOperationClaimTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "OperationClaims",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "OperationClaims",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "OperationClaims",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "OperationClaims",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OperationClaims");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "OperationClaims");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "OperationClaims");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "OperationClaims");
        }
    }
}
