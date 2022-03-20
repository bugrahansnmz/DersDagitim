using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DersDagitimProjesi.Migrations
{
    public partial class sabit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BaslangicSaati",
                table: "SabitBilgis",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BaslangicSaati",
                table: "SabitBilgis",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
