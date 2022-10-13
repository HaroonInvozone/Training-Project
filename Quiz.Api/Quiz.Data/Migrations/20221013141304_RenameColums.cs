using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Data.Migrations
{
    public partial class RenameColums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalQuestions",
                table: "Results",
                newName: "TotalQuestion");

            migrationBuilder.RenameColumn(
                name: "CorrectAnswers",
                table: "Results",
                newName: "CorrectAnswer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalQuestion",
                table: "Results",
                newName: "TotalQuestions");

            migrationBuilder.RenameColumn(
                name: "CorrectAnswer",
                table: "Results",
                newName: "CorrectAnswers");
        }
    }
}
