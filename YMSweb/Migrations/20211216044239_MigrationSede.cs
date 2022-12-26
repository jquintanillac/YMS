using Microsoft.EntityFrameworkCore.Migrations;

namespace YMSweb.Migrations
{
    public partial class MigrationSede : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rol_Usuario_Usuario_IdUsuario",
                table: "Rol_Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Rol_Usuario_IdUsuario",
                table: "Rol_Usuario");

            migrationBuilder.AddColumn<int>(
                name: "id_sede",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DUsuarioIdUsuario",
                table: "Rol_Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rol_Usuario_DUsuarioIdUsuario",
                table: "Rol_Usuario",
                column: "DUsuarioIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Rol_Usuario_Usuario_DUsuarioIdUsuario",
                table: "Rol_Usuario",
                column: "DUsuarioIdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rol_Usuario_Usuario_DUsuarioIdUsuario",
                table: "Rol_Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Rol_Usuario_DUsuarioIdUsuario",
                table: "Rol_Usuario");

            migrationBuilder.DropColumn(
                name: "id_sede",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DUsuarioIdUsuario",
                table: "Rol_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_Usuario_IdUsuario",
                table: "Rol_Usuario",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Rol_Usuario_Usuario_IdUsuario",
                table: "Rol_Usuario",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
