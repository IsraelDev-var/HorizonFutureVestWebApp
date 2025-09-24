using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coutries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ISOCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coutries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Macroindicador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    HigherIsBetter = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Macroindicador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TasaRetono",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinimunRete = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaximunRete = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasaRetono", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndicadorePorPaises",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    MacroindicatorId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", maxLength: 200, nullable: false),
                    Year = table.Column<DateOnly>(type: "date", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadorePorPaises", x => new { x.CountryId, x.MacroindicatorId });
                    table.ForeignKey(
                        name: "FK_IndicadorePorPaises_Coutries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Coutries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndicadorePorPaises_Macroindicador_MacroindicatorId",
                        column: x => x.MacroindicatorId,
                        principalTable: "Macroindicador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SimulacionMacroIndicador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SimulationWeight = table.Column<int>(type: "int", nullable: false),
                    MacroindicatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimulacionMacroIndicador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimulacionMacroIndicador_Macroindicador_MacroindicatorId",
                        column: x => x.MacroindicatorId,
                        principalTable: "Macroindicador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorePorPaises_MacroindicatorId",
                table: "IndicadorePorPaises",
                column: "MacroindicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SimulacionMacroIndicador_MacroindicatorId",
                table: "SimulacionMacroIndicador",
                column: "MacroindicatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndicadorePorPaises");

            migrationBuilder.DropTable(
                name: "SimulacionMacroIndicador");

            migrationBuilder.DropTable(
                name: "TasaRetono");

            migrationBuilder.DropTable(
                name: "Coutries");

            migrationBuilder.DropTable(
                name: "Macroindicador");
        }
    }
}
