using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiFilme.Migrations
{
    public partial class HorasTrabalhadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HorasTrabalhadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ManhaTurnoInicio = table.Column<TimeOnly>(type: "time(6)", nullable: true),
                    ManhaTurnoFim = table.Column<TimeOnly>(type: "time(6)", nullable: true),
                    TardeTurnoInicio = table.Column<TimeOnly>(type: "time(6)", nullable: true),
                    TardeTurnoFim = table.Column<TimeOnly>(type: "time(6)", nullable: true),
                    NoiteTurnoInicio = table.Column<TimeOnly>(type: "time(6)", nullable: true),
                    NoiteTurnoFim = table.Column<TimeOnly>(type: "time(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorasTrabalhadas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorasTrabalhadas");
        }
    }
}
