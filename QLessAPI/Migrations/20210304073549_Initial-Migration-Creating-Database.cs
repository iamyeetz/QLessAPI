using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLessAPI.Migrations
{
    public partial class InitialMigrationCreatingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardType",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", nullable: true),
                    Discount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TransportCard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Load = table.Column<decimal>(nullable: false),
                    CardTypeId = table.Column<int>(nullable: false),
                    DateRegistered = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastDateUsed = table.Column<DateTime>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportCard_CardType_CardTypeId",
                        column: x => x.CardTypeId,
                        principalTable: "CardType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCardDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportCardId = table.Column<int>(nullable: false),
                    GovernmentIdNumber = table.Column<string>(type: "varchar(14)", nullable: true),
                    GovernmentIdType = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCardDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountCardDetails_TransportCard_TransportCardId",
                        column: x => x.TransportCardId,
                        principalTable: "TransportCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportCardId = table.Column<int>(nullable: false),
                    FromStationId = table.Column<int>(nullable: false),
                    ToStationId = table.Column<int>(nullable: false),
                    MrtLine = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    TrasportDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transport_TransportCard_TransportCardId",
                        column: x => x.TransportCardId,
                        principalTable: "TransportCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCardDetails_TransportCardId",
                table: "DiscountCardDetails",
                column: "TransportCardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transport_TransportCardId",
                table: "Transport",
                column: "TransportCardId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportCard_CardTypeId",
                table: "TransportCard",
                column: "CardTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountCardDetails");

            migrationBuilder.DropTable(
                name: "Transport");

            migrationBuilder.DropTable(
                name: "TransportCard");

            migrationBuilder.DropTable(
                name: "CardType");
        }
    }
}
