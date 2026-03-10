using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiInator.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GgDealsInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentRetailPrice_Value = table.Column<double>(type: "float", nullable: false),
                    CurrentRetailPrice_CurrentRetailPrice_CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentKeyshopPrice_Value = table.Column<double>(type: "float", nullable: false),
                    CurrentKeyshopPrice_CurrentKeyshopPrice_CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HistoricalRetailPrice_Value = table.Column<double>(type: "float", nullable: false),
                    HistoricalRetailPrice_HistoricalRetailPrice_CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HistoricalKeyshopPrice_Value = table.Column<double>(type: "float", nullable: false),
                    HistoricalKeyshopPrice_HistoricalKeyshopPrice_CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GgDealsInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GgDealsInfo_Currency_CurrentKeyshopPrice_CurrentKeyshopPrice_CurrencyId",
                        column: x => x.CurrentKeyshopPrice_CurrentKeyshopPrice_CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GgDealsInfo_Currency_CurrentRetailPrice_CurrentRetailPrice_CurrencyId",
                        column: x => x.CurrentRetailPrice_CurrentRetailPrice_CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GgDealsInfo_Currency_HistoricalKeyshopPrice_HistoricalKeyshopPrice_CurrencyId",
                        column: x => x.HistoricalKeyshopPrice_HistoricalKeyshopPrice_CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GgDealsInfo_Currency_HistoricalRetailPrice_HistoricalRetailPrice_CurrencyId",
                        column: x => x.HistoricalRetailPrice_HistoricalRetailPrice_CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GgDealsInfo_GameInfo_Id",
                        column: x => x.Id,
                        principalTable: "GameInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HowLongToBeatInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HowLongToBeatId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Completionist = table.Column<double>(type: "float", nullable: false),
                    MainStory = table.Column<double>(type: "float", nullable: false),
                    MainExtra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    Releases = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HowLongToBeatInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HowLongToBeatInfo_GameInfo_Id",
                        column: x => x.Id,
                        principalTable: "GameInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenCriticInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpenCriticId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedianScore = table.Column<double>(type: "float", nullable: false),
                    PercentRecomended = table.Column<double>(type: "float", nullable: false),
                    HasLootboxes = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenCriticInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenCriticInfo_GameInfo_Id",
                        column: x => x.Id,
                        principalTable: "GameInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SteamInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SteamAppId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InitialPrice_Value = table.Column<double>(type: "float", nullable: false),
                    InitialPrice_InitialPrice_CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteamInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SteamInfo_Currency_InitialPrice_InitialPrice_CurrencyId",
                        column: x => x.InitialPrice_InitialPrice_CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SteamInfo_GameInfo_Id",
                        column: x => x.Id,
                        principalTable: "GameInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GgDealsInfo_CurrentKeyshopPrice_CurrentKeyshopPrice_CurrencyId",
                table: "GgDealsInfo",
                column: "CurrentKeyshopPrice_CurrentKeyshopPrice_CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_GgDealsInfo_CurrentRetailPrice_CurrentRetailPrice_CurrencyId",
                table: "GgDealsInfo",
                column: "CurrentRetailPrice_CurrentRetailPrice_CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_GgDealsInfo_HistoricalKeyshopPrice_HistoricalKeyshopPrice_CurrencyId",
                table: "GgDealsInfo",
                column: "HistoricalKeyshopPrice_HistoricalKeyshopPrice_CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_GgDealsInfo_HistoricalRetailPrice_HistoricalRetailPrice_CurrencyId",
                table: "GgDealsInfo",
                column: "HistoricalRetailPrice_HistoricalRetailPrice_CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SteamInfo_InitialPrice_InitialPrice_CurrencyId",
                table: "SteamInfo",
                column: "InitialPrice_InitialPrice_CurrencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GgDealsInfo");

            migrationBuilder.DropTable(
                name: "HowLongToBeatInfo");

            migrationBuilder.DropTable(
                name: "OpenCriticInfo");

            migrationBuilder.DropTable(
                name: "SteamInfo");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "GameInfo");
        }
    }
}
