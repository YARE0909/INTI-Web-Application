using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCardPortalINTI.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationDetailsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "CardApplications",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "CardApplications",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "CardApplications");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CardApplications");
        }
    }
}
