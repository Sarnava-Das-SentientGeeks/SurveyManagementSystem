using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FinalSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Response_ResponseId",
                table: "Answers");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Response_ResponseId",
                table: "Answers",
                column: "ResponseId",
                principalTable: "Response",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Response_ResponseId",
                table: "Answers");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Response_ResponseId",
                table: "Answers",
                column: "ResponseId",
                principalTable: "Response",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
