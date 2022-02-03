using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoPersistence.Migrations
{
    public partial class _2_UserNowHasId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Users_ResponsibleUsername",
                table: "Todos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Todos_ResponsibleUsername",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "ResponsibleUsername",
                table: "Todos");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ResponsibleId",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Todos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_ResponsibleId",
                table: "Todos",
                column: "ResponsibleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Users_ResponsibleId",
                table: "Todos",
                column: "ResponsibleId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Users_ResponsibleId",
                table: "Todos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Todos_ResponsibleId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ResponsibleId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Todos");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleUsername",
                table: "Todos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_ResponsibleUsername",
                table: "Todos",
                column: "ResponsibleUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Users_ResponsibleUsername",
                table: "Todos",
                column: "ResponsibleUsername",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
