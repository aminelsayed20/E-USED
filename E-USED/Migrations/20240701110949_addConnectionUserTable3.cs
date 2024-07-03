using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_USED.Migrations
{
    /// <inheritdoc />
    public partial class addConnectionUserTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionUsers_AspNetUsers_UserId",
                table: "ConnectionUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionUsers_Connection_ConnectionId",
                table: "ConnectionUsers");

            migrationBuilder.DropTable(
                name: "Connection");

            migrationBuilder.DropIndex(
                name: "IX_ConnectionUsers_ConnectionId",
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

            migrationBuilder.AlterColumn<string>(
                name: "ConnectionId",
                table: "ConnectionUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ConnectionUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ConnectionId",
                table: "ConnectionUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Connection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connection", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionUsers_ConnectionId",
                table: "ConnectionUsers",
                column: "ConnectionId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionUsers_Connection_ConnectionId",
                table: "ConnectionUsers",
                column: "ConnectionId",
                principalTable: "Connection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
