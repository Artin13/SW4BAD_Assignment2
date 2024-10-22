using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SW4BADAssignment2.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FoodSafetyCertified",
                table: "Cooks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodSafetyCertified",
                table: "Cooks");
        }
    }
}
