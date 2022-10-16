using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace studentFreelance.Data.Migrations
{
    public partial class initia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_timmings_sports_sports_Id",
                table: "timmings");

            migrationBuilder.DropIndex(
                name: "IX_timmings_sports_Id",
                table: "timmings");

            migrationBuilder.AlterColumn<int>(
                name: "sports_Id",
                table: "timmings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "sports_Id1",
                table: "timmings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_timmings_sports_Id1",
                table: "timmings",
                column: "sports_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_timmings_sports_sports_Id1",
                table: "timmings",
                column: "sports_Id1",
                principalTable: "sports",
                principalColumn: "sports_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_timmings_sports_sports_Id1",
                table: "timmings");

            migrationBuilder.DropIndex(
                name: "IX_timmings_sports_Id1",
                table: "timmings");

            migrationBuilder.DropColumn(
                name: "sports_Id1",
                table: "timmings");

            migrationBuilder.AlterColumn<int>(
                name: "sports_Id",
                table: "timmings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_timmings_sports_Id",
                table: "timmings",
                column: "sports_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_timmings_sports_sports_Id",
                table: "timmings",
                column: "sports_Id",
                principalTable: "sports",
                principalColumn: "sports_Id");
        }
    }
}
