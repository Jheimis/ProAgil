using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProAgil.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eventos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    local = table.Column<string>(nullable: true),
                    dataEvento = table.Column<DateTime>(nullable: false),
                    tema = table.Column<string>(nullable: true),
                    qtdPessoas = table.Column<int>(nullable: false),
                    telefone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    imageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "palestrantes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(nullable: true),
                    miniCurriculo = table.Column<string>(nullable: true),
                    imagemURL = table.Column<string>(nullable: true),
                    telefone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_palestrantes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lotes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(nullable: true),
                    preco = table.Column<decimal>(nullable: false),
                    dataInicio = table.Column<DateTime>(nullable: true),
                    dataFim = table.Column<DateTime>(nullable: true),
                    quantidade = table.Column<int>(nullable: false),
                    eventoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lotes", x => x.id);
                    table.ForeignKey(
                        name: "FK_lotes_eventos_eventoId",
                        column: x => x.eventoId,
                        principalTable: "eventos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "palestrantesEventos",
                columns: table => new
                {
                    palestranteId = table.Column<int>(nullable: false),
                    eventoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_palestrantesEventos", x => new { x.eventoId, x.palestranteId });
                    table.ForeignKey(
                        name: "FK_palestrantesEventos_eventos_eventoId",
                        column: x => x.eventoId,
                        principalTable: "eventos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_palestrantesEventos_palestrantes_palestranteId",
                        column: x => x.palestranteId,
                        principalTable: "palestrantes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "redesSociais",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    eventoId = table.Column<int>(nullable: true),
                    palestranteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_redesSociais", x => x.id);
                    table.ForeignKey(
                        name: "FK_redesSociais_eventos_eventoId",
                        column: x => x.eventoId,
                        principalTable: "eventos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_redesSociais_palestrantes_palestranteId",
                        column: x => x.palestranteId,
                        principalTable: "palestrantes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lotes_eventoId",
                table: "lotes",
                column: "eventoId");

            migrationBuilder.CreateIndex(
                name: "IX_palestrantesEventos_palestranteId",
                table: "palestrantesEventos",
                column: "palestranteId");

            migrationBuilder.CreateIndex(
                name: "IX_redesSociais_eventoId",
                table: "redesSociais",
                column: "eventoId");

            migrationBuilder.CreateIndex(
                name: "IX_redesSociais_palestranteId",
                table: "redesSociais",
                column: "palestranteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lotes");

            migrationBuilder.DropTable(
                name: "palestrantesEventos");

            migrationBuilder.DropTable(
                name: "redesSociais");

            migrationBuilder.DropTable(
                name: "eventos");

            migrationBuilder.DropTable(
                name: "palestrantes");
        }
    }
}
