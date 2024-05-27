using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiFilme.Migrations
{
    public partial class incluirHorariosPadraoDataAgenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraConclusao",
                table: "Agendas",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraInicio",
                table: "Agendas",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraConclusao",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "HoraInicio",
                table: "Agendas");
        }
    }
}
