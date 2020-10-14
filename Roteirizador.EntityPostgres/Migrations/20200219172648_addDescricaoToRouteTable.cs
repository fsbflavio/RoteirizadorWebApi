using Microsoft.EntityFrameworkCore.Migrations;

namespace Roterizador.EntityPostgres.Migrations
{
    public partial class addDescricaoToRouteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DESCRICAO",
                table: "ROT_ROUTES",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DESCRICAO",
                table: "ROT_ROUTES");
        }
    }
}
