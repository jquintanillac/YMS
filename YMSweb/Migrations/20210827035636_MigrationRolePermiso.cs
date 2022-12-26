using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YMSweb.Migrations
{
    public partial class MigrationRolePermiso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "vijcab_horapropuesta",
                table: "Viaje_Cabecera",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "mue_obs",
                table: "Muelle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "esta_obs",
                table: "Estacionamiento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cua_obs",
                table: "Cuadrilla",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "can_obs",
                table: "Canal",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    id_menu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    menu_iden = table.Column<int>(type: "int", nullable: false),
                    menu_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.id_menu);
                });

            migrationBuilder.CreateTable(
                name: "Rol_Permisos",
                columns: table => new
                {
                    id_rolperm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idrol = table.Column<int>(type: "int", nullable: false),
                    id_menu = table.Column<int>(type: "int", nullable: false),
                    id_submenu = table.Column<int>(type: "int", nullable: false),
                    rolperm_act = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol_Permisos", x => x.id_rolperm);
                });

            migrationBuilder.CreateTable(
                name: "Submenu",
                columns: table => new
                {
                    id_submenu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_menu = table.Column<int>(type: "int", nullable: false),
                    submenu_iden = table.Column<int>(type: "int", nullable: false),
                    submenu_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submenu", x => x.id_submenu);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Rol_Permisos");

            migrationBuilder.DropTable(
                name: "Submenu");

            migrationBuilder.DropColumn(
                name: "vijcab_horapropuesta",
                table: "Viaje_Cabecera");

            migrationBuilder.DropColumn(
                name: "mue_obs",
                table: "Muelle");

            migrationBuilder.DropColumn(
                name: "esta_obs",
                table: "Estacionamiento");

            migrationBuilder.DropColumn(
                name: "cua_obs",
                table: "Cuadrilla");

            migrationBuilder.DropColumn(
                name: "can_obs",
                table: "Canal");
        }
    }
}
