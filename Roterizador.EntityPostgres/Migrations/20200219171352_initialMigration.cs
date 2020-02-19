using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Roterizador.EntityPostgres.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ROT_ROUTES",
                columns: table => new
                {
                    ID_ROUTE = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROT_ROUTES", x => x.ID_ROUTE);
                });

            migrationBuilder.CreateTable(
                name: "ROT_COORDINATES",
                columns: table => new
                {
                    ID_COORDINATE = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LONGITUDE = table.Column<float>(nullable: false),
                    LATITUDE = table.Column<float>(nullable: false),
                    ID_ROUTE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROT_COORDINATES", x => x.ID_COORDINATE);
                    table.ForeignKey(
                        name: "FK_ROT_COORDINATES_ROT_ROUTES_ID_ROUTE",
                        column: x => x.ID_ROUTE,
                        principalTable: "ROT_ROUTES",
                        principalColumn: "ID_ROUTE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ROT_COORDINATES_ID_ROUTE",
                table: "ROT_COORDINATES",
                column: "ID_ROUTE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ROT_COORDINATES");

            migrationBuilder.DropTable(
                name: "ROT_ROUTES");
        }
    }
}
