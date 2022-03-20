using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DersDagitimProjesi.Migrations
{
    public partial class qwe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OgretmenBosGun",
                table: "SabitBilgis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OgretmenBosGun",
                table: "SabitBilgis",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
