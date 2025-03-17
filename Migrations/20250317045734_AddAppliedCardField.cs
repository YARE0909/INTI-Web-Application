using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCardPortalINTI.Migrations
{
    /// <inheritdoc />
    public partial class AddAppliedCardField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppliedCard",
                table: "Customers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppliedCard",
                table: "Customers");
        }
    }
}
