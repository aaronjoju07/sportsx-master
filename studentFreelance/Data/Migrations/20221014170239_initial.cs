using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace studentFreelance.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productnamec = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    productDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productid);
                });

            migrationBuilder.CreateTable(
                name: "venue",
                columns: table => new
                {
                    venue_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    venue_desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    venue_pic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    venue_location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venue", x => x.venue_name);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    booking_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    productsproductid = table.Column<int>(type: "int", nullable: true),
                    type = table.Column<bool>(type: "bit", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payment_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.booking_Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Products_productsproductid",
                        column: x => x.productsproductid,
                        principalTable: "Products",
                        principalColumn: "productid");
                });

            migrationBuilder.CreateTable(
                name: "spoorts",
                columns: table => new
                {
                    sportts = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    sport_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    venue_name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spoorts", x => x.sportts);
                    table.ForeignKey(
                        name: "FK_spoorts_venue_venue_name",
                        column: x => x.venue_name,
                        principalTable: "venue",
                        principalColumn: "venue_name");
                });

            migrationBuilder.CreateTable(
                name: "sports",
                columns: table => new
                {
                    sports_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    venue_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    sportts = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    slot_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sports", x => x.sports_Id);
                    table.ForeignKey(
                        name: "FK_sports_spoorts_sportts",
                        column: x => x.sportts,
                        principalTable: "spoorts",
                        principalColumn: "sportts",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sports_venue_venue_name",
                        column: x => x.venue_name,
                        principalTable: "venue",
                        principalColumn: "venue_name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "timmings",
                columns: table => new
                {
                    t_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    s_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    s1 = table.Column<bool>(type: "bit", nullable: false),
                    s2 = table.Column<bool>(type: "bit", nullable: false),
                    s3 = table.Column<bool>(type: "bit", nullable: false),
                    s4 = table.Column<bool>(type: "bit", nullable: false),
                    s5 = table.Column<bool>(type: "bit", nullable: false),
                    s6 = table.Column<bool>(type: "bit", nullable: false),
                    s7 = table.Column<bool>(type: "bit", nullable: false),
                    s8 = table.Column<bool>(type: "bit", nullable: false),
                    s9 = table.Column<bool>(type: "bit", nullable: false),
                    s10 = table.Column<bool>(type: "bit", nullable: false),
                    s11 = table.Column<bool>(type: "bit", nullable: false),
                    s12 = table.Column<bool>(type: "bit", nullable: false),
                    s13 = table.Column<bool>(type: "bit", nullable: false),
                    s14 = table.Column<bool>(type: "bit", nullable: false),
                    s15 = table.Column<bool>(type: "bit", nullable: false),
                    s16 = table.Column<bool>(type: "bit", nullable: false),
                    s17 = table.Column<bool>(type: "bit", nullable: false),
                    s18 = table.Column<bool>(type: "bit", nullable: false),
                    s19 = table.Column<bool>(type: "bit", nullable: false),
                    sports_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timmings", x => x.t_Id);
                    table.ForeignKey(
                        name: "FK_timmings_sports_sports_Id",
                        column: x => x.sports_Id,
                        principalTable: "sports",
                        principalColumn: "sports_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_productsproductid",
                table: "Bookings",
                column: "productsproductid");

            migrationBuilder.CreateIndex(
                name: "IX_spoorts_venue_name",
                table: "spoorts",
                column: "venue_name");

            migrationBuilder.CreateIndex(
                name: "IX_sports_sportts",
                table: "sports",
                column: "sportts");

            migrationBuilder.CreateIndex(
                name: "IX_sports_venue_name",
                table: "sports",
                column: "venue_name");

            migrationBuilder.CreateIndex(
                name: "IX_timmings_sports_Id",
                table: "timmings",
                column: "sports_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "timmings");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "sports");

            migrationBuilder.DropTable(
                name: "spoorts");

            migrationBuilder.DropTable(
                name: "venue");
        }
    }
}
