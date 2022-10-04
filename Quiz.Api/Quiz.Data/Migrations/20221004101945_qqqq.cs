using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Data.Migrations
{
    public partial class qqqq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Test_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Start_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Correct_Answers = table.Column<int>(type: "int", nullable: false),
                    Total_Questions = table.Column<int>(type: "int", nullable: false),
                    Current_State = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResultAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Answer_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Result_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultAnswers_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResultAnswers_Questions_Question_Id",
                        column: x => x.Question_Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultAnswers_Results_Result_Id",
                        column: x => x.Result_Id,
                        principalTable: "Results",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResultAnswers_AnswerId",
                table: "ResultAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultAnswers_Question_Id",
                table: "ResultAnswers",
                column: "Question_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ResultAnswers_Result_Id",
                table: "ResultAnswers",
                column: "Result_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Results_UserId",
                table: "Results",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultAnswers");

            migrationBuilder.DropTable(
                name: "Results");
        }
    }
}
