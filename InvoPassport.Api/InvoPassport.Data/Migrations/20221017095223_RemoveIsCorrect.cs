using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Data.Migrations
{
    public partial class RemoveIsCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "ResultAnswers");

            migrationBuilder.CreateIndex(
                name: "IX_ResultAnswers_AnswerId",
                table: "ResultAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultAnswers_QuestionId",
                table: "ResultAnswers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultAnswers_Answers_AnswerId",
                table: "ResultAnswers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultAnswers_Questions_QuestionId",
                table: "ResultAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultAnswers_Answers_AnswerId",
                table: "ResultAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultAnswers_Questions_QuestionId",
                table: "ResultAnswers");

            migrationBuilder.DropIndex(
                name: "IX_ResultAnswers_AnswerId",
                table: "ResultAnswers");

            migrationBuilder.DropIndex(
                name: "IX_ResultAnswers_QuestionId",
                table: "ResultAnswers");

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "ResultAnswers",
                type: "bit",
                nullable: true);
        }
    }
}
