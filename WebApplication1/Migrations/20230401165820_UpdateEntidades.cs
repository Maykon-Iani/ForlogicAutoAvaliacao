using Microsoft.EntityFrameworkCore.Migrations;

namespace ForlogicAutoAvaliacao.Migrations
{
    public partial class UpdateEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Avaliacao_id_avaliacao",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_id_avaliacao",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "id_avaliacao",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "id_cliente",
                table: "Avaliacao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_id_cliente",
                table: "Avaliacao",
                column: "id_cliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Cliente_id_cliente",
                table: "Avaliacao",
                column: "id_cliente",
                principalTable: "Cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Cliente_id_cliente",
                table: "Avaliacao");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacao_id_cliente",
                table: "Avaliacao");

            migrationBuilder.DropColumn(
                name: "id_cliente",
                table: "Avaliacao");

            migrationBuilder.AddColumn<int>(
                name: "id_avaliacao",
                table: "Cliente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_id_avaliacao",
                table: "Cliente",
                column: "id_avaliacao");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Avaliacao_id_avaliacao",
                table: "Cliente",
                column: "id_avaliacao",
                principalTable: "Avaliacao",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
