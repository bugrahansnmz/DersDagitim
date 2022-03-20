using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DersDagitimProjesi.Migrations
{
    public partial class ogle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SabahciOgleci",
                table: "SabitBilgis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SabahciOgleci",
                table: "SabitBilgis",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
