using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Roterizador.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ROT_COORDINATES",
                columns: table => new
                {
                    ID_COORDINATE = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Longitude = table.Column<float>(nullable: false),
                    Latitude = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROT_COORDINATES", x => x.ID_COORDINATE);
                });

            migrationBuilder.CreateTable(
                name: "ROT_ROUTES",
                columns: table => new
                {
                    ID_ROUTE = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartId = table.Column<int>(nullable: true),
                    EndId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROT_ROUTES", x => x.ID_ROUTE);
                    table.ForeignKey(
                        name: "FK_ROT_ROUTES_ROT_COORDINATES_EndId",
                        column: x => x.EndId,
                        principalTable: "ROT_COORDINATES",
                        principalColumn: "ID_COORDINATE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ROT_ROUTES_ROT_COORDINATES_StartId",
                        column: x => x.StartId,
                        principalTable: "ROT_COORDINATES",
                        principalColumn: "ID_COORDINATE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ROT_ROUTES_EndId",
                table: "ROT_ROUTES",
                column: "EndId");

            migrationBuilder.CreateIndex(
                name: "IX_ROT_ROUTES_StartId",
                table: "ROT_ROUTES",
                column: "StartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ROT_ROUTES");

            migrationBuilder.DropTable(
                name: "ROT_COORDINATES");
        }
    }
}
