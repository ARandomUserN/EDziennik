using Microsoft.EntityFrameworkCore.Migrations;

namespace EDziennik.Migrations
{
    public partial class StudentID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mark_AspNetUsers_studentId",
                schema: "Identity",
                table: "Mark");

            migrationBuilder.AlterColumn<string>(
                name: "studentId",
                schema: "Identity",
                table: "Mark",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "studentId",
                schema: "Identity",
                table: "Mark",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Mark_AspNetUsers_studentId",
                schema: "Identity",
                table: "Mark",
                column: "studentId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
