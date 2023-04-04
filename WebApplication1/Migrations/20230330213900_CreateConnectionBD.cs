using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForlogicAutoAvaliacao.Migrations
{
    public partial class CreateConnectionBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    mes_ano = table.Column<DateTime>(nullable: false),
                    nota = table.Column<int>(nullable: false),
                    motivo = table.Column<string>(maxLength: 250, nullable: false),
                    categoria = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    nome = table.Column<string>(maxLength: 100, nullable: false),
                    nome_contato = table.Column<string>(maxLength: 100, nullable: false),
                    cnpj = table.Column<string>(maxLength: 14, nullable: true),
                    id_avaliacao = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cliente_Avaliacao_id_avaliacao",
                        column: x => x.id_avaliacao,
                        principalTable: "Avaliacao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_id_avaliacao",
                table: "Cliente",
                column: "id_avaliacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Avaliacao");
        }
    }
}
