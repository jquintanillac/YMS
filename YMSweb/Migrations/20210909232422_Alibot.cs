using Microsoft.EntityFrameworkCore.Migrations;

namespace YMSweb.Migrations
{
    public partial class Alibot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alibot",
                columns: table => new
                {
                    idalibot = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    app = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alibot", x => x.idalibot);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alibot");
        }
    }
}
