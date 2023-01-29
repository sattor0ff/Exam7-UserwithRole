using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginDto_Users_UserId",
                table: "UserLoginDto");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_LoginDto_LoginDtoUsername",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins");

            migrationBuilder.DropTable(
                name: "LoginDto");

            migrationBuilder.DropIndex(
                name: "IX_UserLogins_LoginDtoUsername",
                table: "UserLogins");

            migrationBuilder.DropIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLoginDto",
                table: "UserLoginDto");

            migrationBuilder.DropIndex(
                name: "IX_UserLoginDto_UserId",
                table: "UserLoginDto");

            migrationBuilder.DropColumn(
                name: "LoginDtoUsername",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserLogins");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserLoginDto",
                newName: "UserId1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserLoginDto",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "UserId1",
                table: "UserLoginDto",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLoginDto",
                table: "UserLoginDto",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginDto_UserId1",
                table: "UserLoginDto",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginDto_Users_UserId1",
                table: "UserLoginDto",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginDto_Users_UserId1",
                table: "UserLoginDto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLoginDto",
                table: "UserLoginDto");

            migrationBuilder.DropIndex(
                name: "IX_UserLoginDto_UserId1",
                table: "UserLoginDto");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "UserLoginDto",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "LoginDtoUsername",
                table: "UserLogins",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserLogins",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserLoginDto",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserLoginDto",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLoginDto",
                table: "UserLoginDto",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LoginDto",
                columns: table => new
                {
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginDto", x => x.Username);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_LoginDtoUsername",
                table: "UserLogins",
                column: "LoginDtoUsername");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginDto_UserId",
                table: "UserLoginDto",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginDto_Users_UserId",
                table: "UserLoginDto",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_LoginDto_LoginDtoUsername",
                table: "UserLogins",
                column: "LoginDtoUsername",
                principalTable: "LoginDto",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
