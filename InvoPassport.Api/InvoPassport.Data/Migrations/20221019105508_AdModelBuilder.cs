using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Data.Migrations
{
    public partial class AdModelBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultAnswers_Answers_AnswerId",
                table: "ResultAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultAnswers_Questions_QuestionId",
                table: "ResultAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultAnswers_Results_ResultId",
                table: "ResultAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Users_UserId",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Results",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResultAnswers",
                table: "ResultAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.RenameTable(
                name: "Results",
                newName: "Result");

            migrationBuilder.RenameTable(
                name: "ResultAnswers",
                newName: "ResultAnswer");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "Answer");

            migrationBuilder.RenameIndex(
                name: "IX_Results_UserId",
                table: "Result",
                newName: "IX_Result_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ResultAnswers_ResultId",
                table: "ResultAnswer",
                newName: "IX_ResultAnswer_ResultId");

            migrationBuilder.RenameIndex(
                name: "IX_ResultAnswers_QuestionId",
                table: "ResultAnswer",
                newName: "IX_ResultAnswer_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_ResultAnswers_AnswerId",
                table: "ResultAnswer",
                newName: "IX_ResultAnswer_AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionId",
                table: "Answer",
                newName: "IX_Answer_QuestionId");

            migrationBuilder.AlterColumn<int>(
                name: "PassId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Result",
                table: "Result",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResultAnswer",
                table: "ResultAnswer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answer",
                table: "Answer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_QuestionId",
                table: "Answer",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Users_UserId",
                table: "Result",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultAnswer_Answer_AnswerId",
                table: "ResultAnswer",
                column: "AnswerId",
                principalTable: "Answer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultAnswer_Question_QuestionId",
                table: "ResultAnswer",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultAnswer_Result_ResultId",
                table: "ResultAnswer",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Users_UserId",
                table: "Result");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultAnswer_Answer_AnswerId",
                table: "ResultAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultAnswer_Question_QuestionId",
                table: "ResultAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultAnswer_Result_ResultId",
                table: "ResultAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResultAnswer",
                table: "ResultAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Result",
                table: "Result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answer",
                table: "Answer");

            migrationBuilder.RenameTable(
                name: "ResultAnswer",
                newName: "ResultAnswers");

            migrationBuilder.RenameTable(
                name: "Result",
                newName: "Results");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "Answer",
                newName: "Answers");

            migrationBuilder.RenameIndex(
                name: "IX_ResultAnswer_ResultId",
                table: "ResultAnswers",
                newName: "IX_ResultAnswers_ResultId");

            migrationBuilder.RenameIndex(
                name: "IX_ResultAnswer_QuestionId",
                table: "ResultAnswers",
                newName: "IX_ResultAnswers_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_ResultAnswer_AnswerId",
                table: "ResultAnswers",
                newName: "IX_ResultAnswers_AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_Result_UserId",
                table: "Results",
                newName: "IX_Results_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_QuestionId",
                table: "Answers",
                newName: "IX_Answers_QuestionId");

            migrationBuilder.AlterColumn<string>(
                name: "PassId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResultAnswers",
                table: "ResultAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results",
                table: "Results",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ResultAnswers_Results_ResultId",
                table: "ResultAnswers",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Users_UserId",
                table: "Results",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
