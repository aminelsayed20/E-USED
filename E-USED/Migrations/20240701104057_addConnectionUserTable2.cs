using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_USED.Migrations
{
    /// <inheritdoc />
    public partial class addConnectionUserTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionUsers_AspNetUsers_UserId1",
                table: "ConnectionUsers");

            migrationBuilder.DropIndex(
                name: "IX_ConnectionUsers_UserId1",
                table: "ConnectionUsers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ConnectionUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ConnectionUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionUsers_UserId",
                table: "ConnectionUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionUsers_AspNetUsers_UserId",
                table: "ConnectionUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionUsers_AspNetUsers_UserId",
                table: "ConnectionUsers");

            migrationBuilder.DropIndex(
                name: "IX_ConnectionUsers_UserId",
                table: "ConnectionUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ConnectionUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ConnectionUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionUsers_UserId1",
                table: "ConnectionUsers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionUsers_AspNetUsers_UserId1",
                table: "ConnectionUsers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
