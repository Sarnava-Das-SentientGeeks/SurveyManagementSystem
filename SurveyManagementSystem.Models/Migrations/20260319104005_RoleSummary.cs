using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RoleSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Role",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Role");
        }
    }
}
