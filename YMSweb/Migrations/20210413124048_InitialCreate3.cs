using Microsoft.EntityFrameworkCore.Migrations;

namespace YMSweb.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Muelle_mue_desc",
                table: "Muelle");

            migrationBuilder.DropIndex(
                name: "IX_Estacionamiento_esta_desc",
                table: "Estacionamiento");

            migrationBuilder.DropIndex(
                name: "IX_Cuadrilla_cua_desc",
                table: "Cuadrilla");

            migrationBuilder.DropIndex(
                name: "IX_Canal_can_desc",
                table: "Canal");

            migrationBuilder.AlterColumn<string>(
                name: "tipuni_desc",
                table: "Tipo_Unidad",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "id_tipo",
                table: "Placa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "mue_cod",
                table: "Muelle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "campla_fase",
                table: "Camiones_Planificados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Muelle_mue_desc",
                table: "Muelle",
                column: "mue_desc");

            migrationBuilder.CreateIndex(
                name: "IX_Estacionamiento_esta_desc",
                table: "Estacionamiento",
                column: "esta_desc");

            migrationBuilder.CreateIndex(
                name: "IX_Cuadrilla_cua_desc",
                table: "Cuadrilla",
                column: "cua_desc");

            migrationBuilder.CreateIndex(
                name: "IX_Canal_can_desc",
                table: "Canal",
                column: "can_desc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Muelle_mue_desc",
                table: "Muelle");

            migrationBuilder.DropIndex(
                name: "IX_Estacionamiento_esta_desc",
                table: "Estacionamiento");

            migrationBuilder.DropIndex(
                name: "IX_Cuadrilla_cua_desc",
                table: "Cuadrilla");

            migrationBuilder.DropIndex(
                name: "IX_Canal_can_desc",
                table: "Canal");

            migrationBuilder.DropColumn(
                name: "id_tipo",
                table: "Placa");

            migrationBuilder.DropColumn(
                name: "mue_cod",
                table: "Muelle");

            migrationBuilder.DropColumn(
                name: "campla_fase",
                table: "Camiones_Planificados");

            migrationBuilder.AlterColumn<string>(
                name: "tipuni_desc",
                table: "Tipo_Unidad",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Muelle_mue_desc",
                table: "Muelle",
                column: "mue_desc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estacionamiento_esta_desc",
                table: "Estacionamiento",
                column: "esta_desc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cuadrilla_cua_desc",
                table: "Cuadrilla",
                column: "cua_desc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Canal_can_desc",
                table: "Canal",
                column: "can_desc",
                unique: true);
        }
    }
}
