using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Card_Api.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CVC",
                table: "Cards",
                newName: "cardCVC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cardCVC",
                table: "Cards",
                newName: "CVC");
        }
    }
}
