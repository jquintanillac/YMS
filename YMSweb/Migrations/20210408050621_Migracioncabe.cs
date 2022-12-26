using Microsoft.EntityFrameworkCore.Migrations;

namespace YMSweb.Migrations
{
    public partial class Migracioncabe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "vijcab_segsal",
                table: "Viaje_Cabecera",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "vijcab_segsal",
                table: "Viaje_Cabecera");
        }
    }
}
