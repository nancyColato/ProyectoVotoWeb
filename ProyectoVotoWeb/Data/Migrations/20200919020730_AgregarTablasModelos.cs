using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoVotoWeb.Data.Migrations
{
    public partial class AgregarTablasModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblRestaurante",
                columns: table => new
                {
                    IdRestaurante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRestaurante = table.Column<string>(nullable: false),
                    Decripcion = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    ImgDestacada = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRestaurante", x => x.IdRestaurante);
                });

            migrationBuilder.CreateTable(
                name: "tblHorario",
                columns: table => new
                {
                    IdHorario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraApertura = table.Column<TimeSpan>(nullable: false),
                    HoraCierre = table.Column<TimeSpan>(nullable: false),
                    DiaInicio = table.Column<string>(nullable: false),
                    DiaFin = table.Column<string>(nullable: false),
                    IdRestaurante = table.Column<int>(nullable: false),
                    tblRestauranteIdRestaurante = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblHorario", x => x.IdHorario);
                    table.ForeignKey(
                        name: "FK_tblHorario_tblRestaurante_tblRestauranteIdRestaurante",
                        column: x => x.tblRestauranteIdRestaurante,
                        principalTable: "tblRestaurante",
                        principalColumn: "IdRestaurante",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblVotacion",
                columns: table => new
                {
                    IdVoto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumVotos = table.Column<int>(nullable: false),
                    IdRestaurante = table.Column<int>(nullable: false),
                    tblRestauranteIdRestaurante = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVotacion", x => x.IdVoto);
                    table.ForeignKey(
                        name: "FK_tblVotacion_tblRestaurante_tblRestauranteIdRestaurante",
                        column: x => x.tblRestauranteIdRestaurante,
                        principalTable: "tblRestaurante",
                        principalColumn: "IdRestaurante",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblHorario_tblRestauranteIdRestaurante",
                table: "tblHorario",
                column: "tblRestauranteIdRestaurante");

            migrationBuilder.CreateIndex(
                name: "IX_tblVotacion_tblRestauranteIdRestaurante",
                table: "tblVotacion",
                column: "tblRestauranteIdRestaurante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblHorario");

            migrationBuilder.DropTable(
                name: "tblVotacion");

            migrationBuilder.DropTable(
                name: "tblRestaurante");
        }
    }
}
