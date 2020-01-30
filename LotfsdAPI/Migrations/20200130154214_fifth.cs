using Microsoft.EntityFrameworkCore.Migrations;

namespace Lotfsd.API.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemGuid",
                table: "ItemInstances",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemGuid",
                table: "ItemInstances");
        }
    }
}
