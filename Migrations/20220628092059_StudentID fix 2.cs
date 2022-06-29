using Microsoft.EntityFrameworkCore.Migrations;

namespace EDziennik.Migrations
{
    public partial class StudentIDfix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mark_AspNetUsers_studentId1",
                schema: "Identity",
                table: "Mark");

            migrationBuilder.DropIndex(
                name: "IX_Mark_studentId1",
                schema: "Identity",
                table: "Mark");

            migrationBuilder.DropColumn(
                name: "studentId1",
                schema: "Identity",
                table: "Mark");

            migrationBuilder.AlterColumn<string>(
                name: "studentId",
                schema: "Identity",
                table: "Mark",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Mark_studentId",
                schema: "Identity",
                table: "Mark",
                column: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mark_AspNetUsers_studentId",
                schema: "Identity",
                table: "Mark",
                column: "studentId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mark_AspNetUsers_studentId",
                schema: "Identity",
                table: "Mark");

            migrationBuilder.DropIndex(
                name: "IX_Mark_studentId",
                schema: "Identity",
                table: "Mark");

            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                schema: "Identity",
                table: "Mark",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "studentId1",
                schema: "Identity",
                table: "Mark",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Mark_studentId1",
                schema: "Identity",
                table: "Mark",
                column: "studentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Mark_AspNetUsers_studentId1",
                schema: "Identity",
                table: "Mark",
                column: "studentId1",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
