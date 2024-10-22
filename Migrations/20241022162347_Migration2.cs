using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SW4BADAssignment2.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SSN",
                table: "Cooks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SSN",
                table: "Cooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
