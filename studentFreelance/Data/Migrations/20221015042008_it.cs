using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace studentFreelance.Data.Migrations
{
    public partial class it : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_timmings_sports_Id",
                table: "timmings",
                column: "sports_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_timmings_sports_sports_Id",
                table: "timmings",
                column: "sports_Id",
                principalTable: "sports",
                principalColumn: "sports_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_timmings_sports_sports_Id",
                table: "timmings");

            migrationBuilder.DropIndex(
                name: "IX_timmings_sports_Id",
                table: "timmings");

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
    }
}
