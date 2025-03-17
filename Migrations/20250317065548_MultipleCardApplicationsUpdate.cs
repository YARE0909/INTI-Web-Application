using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCardPortalINTI.Migrations
{
    /// <inheritdoc />
    public partial class MultipleCardApplicationsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppliedCard",
                table: "Customers");

            migrationBuilder.CreateTable(
                name: "CardApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    CardType = table.Column<string>(type: "TEXT", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardApplications_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardApplications_CustomerId",
                table: "CardApplications",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardApplications");

            migrationBuilder.AddColumn<string>(
                name: "AppliedCard",
                table: "Customers",
                type: "TEXT",
                nullable: true);
        }
    }
}
