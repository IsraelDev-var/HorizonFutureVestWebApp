using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Macroindicador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Weight = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false, defaultValue: 0m),
                    HigherIsBetter = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Macroindicador", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ISOCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TasaRetono",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MinimunRete = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    MaximunRete = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasaRetono", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SimulacionMacroIndicador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IndicadorePorPaises",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    MacroindicatorId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(65,30)", maxLength: 200, nullable: false),
                    Year = table.Column<DateOnly>(type: "date", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadorePorPaises", x => new { x.CountryId, x.MacroindicatorId });
                    table.ForeignKey(
                        name: "FK_IndicadorePorPaises_Macroindicador_MacroindicatorId",
                        column: x => x.MacroindicatorId,
                        principalTable: "Macroindicador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicadorePorPaises_Paises_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorePorPaises_CountryId_MacroindicatorId_Year",
                table: "IndicadorePorPaises",
                columns: new[] { "CountryId", "MacroindicatorId", "Year" },
                unique: true);

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
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Macroindicador");
        }
    }
}
