using Microsoft.EntityFrameworkCore.Migrations;

namespace YMSweb.Migrations
{
    public partial class Descripcion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "monta_cod",
                table: "Montacargas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "esta_cod",
                table: "Estacionamiento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cua_cod",
                table: "Cuadrilla",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "can_cod",
                table: "Canal",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "anex_cod",
                table: "Anexos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "monta_cod",
                table: "Montacargas");

            migrationBuilder.DropColumn(
                name: "esta_cod",
                table: "Estacionamiento");

            migrationBuilder.DropColumn(
                name: "cua_cod",
                table: "Cuadrilla");

            migrationBuilder.DropColumn(
                name: "can_cod",
                table: "Canal");

            migrationBuilder.DropColumn(
                name: "anex_cod",
                table: "Anexos");
        }
    }
}
