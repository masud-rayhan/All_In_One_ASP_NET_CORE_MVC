using Microsoft.EntityFrameworkCore.Migrations;

namespace All_In_One.DataAccess.Migrations
{
    public partial class databasechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentTeacher",
                table: "StudentTeacher");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "StudentTeacher",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentTeacher",
                table: "StudentTeacher",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTeacher_StudentId",
                table: "StudentTeacher",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentTeacher",
                table: "StudentTeacher");

            migrationBuilder.DropIndex(
                name: "IX_StudentTeacher_StudentId",
                table: "StudentTeacher");

            migrationBuilder.DropColumn(
                name: "id",
                table: "StudentTeacher");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentTeacher",
                table: "StudentTeacher",
                columns: new[] { "StudentId", "TeacherId" });
        }
    }
}
