using Microsoft.EntityFrameworkCore.Migrations;

namespace YMSweb.Migrations
{
    public partial class InitialMGalibot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Alibot",
                table: "Alibot");

            migrationBuilder.DropColumn(
                name: "idalibot",
                table: "Alibot");

            migrationBuilder.RenameColumn(
                name: "app",
                table: "Alibot",
                newName: "phone");

            migrationBuilder.AddColumn<string>(
                name: "app_name",
                table: "Alibot",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "group_name",
                table: "Alibot",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alibot",
                table: "Alibot",
                column: "app_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Alibot",
                table: "Alibot");

            migrationBuilder.DropColumn(
                name: "app_name",
                table: "Alibot");

            migrationBuilder.DropColumn(
                name: "group_name",
                table: "Alibot");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Alibot",
                newName: "app");

            migrationBuilder.AddColumn<int>(
                name: "idalibot",
                table: "Alibot",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alibot",
                table: "Alibot",
                column: "idalibot");
        }
    }
}
