using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DersDagitimProjesi.Migrations
{
    public partial class db12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MudurMu",
                table: "Yoneticis");

            migrationBuilder.DropColumn(
                name: "YoneticiAd",
                table: "Yoneticis");

            migrationBuilder.RenameColumn(
                name: "YoneticiSoyad",
                table: "Yoneticis",
                newName: "YoneticiAdSoyad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YoneticiAdSoyad",
                table: "Yoneticis",
                newName: "YoneticiSoyad");

            migrationBuilder.AddColumn<bool>(
                name: "MudurMu",
                table: "Yoneticis",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "YoneticiAd",
                table: "Yoneticis",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
