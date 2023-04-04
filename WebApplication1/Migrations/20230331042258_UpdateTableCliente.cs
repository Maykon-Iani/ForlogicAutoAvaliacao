using Microsoft.EntityFrameworkCore.Migrations;

namespace ForlogicAutoAvaliacao.Migrations
{
    public partial class UpdateTableCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categoria",
                table: "Avaliacao");

            migrationBuilder.AddColumn<string>(
                name: "categoria",
                table: "Cliente",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categoria",
                table: "Cliente");

            migrationBuilder.AddColumn<string>(
                name: "categoria",
                table: "Avaliacao",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
