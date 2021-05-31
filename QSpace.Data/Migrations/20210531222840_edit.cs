using Microsoft.EntityFrameworkCore.Migrations;

namespace QSpace.Data.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_AspNetUsers_InstructorId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_InstructorId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Quizzes");

            migrationBuilder.AddColumn<string>(
                name: "InstructorId1",
                table: "Quizzes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_InstructorId1",
                table: "Quizzes",
                column: "InstructorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_AspNetUsers_InstructorId1",
                table: "Quizzes",
                column: "InstructorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_AspNetUsers_InstructorId1",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_InstructorId1",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "InstructorId1",
                table: "Quizzes");

            migrationBuilder.AddColumn<string>(
                name: "InstructorId",
                table: "Quizzes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_InstructorId",
                table: "Quizzes",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_AspNetUsers_InstructorId",
                table: "Quizzes",
                column: "InstructorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
