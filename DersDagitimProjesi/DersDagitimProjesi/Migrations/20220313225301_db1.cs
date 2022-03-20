using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DersDagitimProjesi.Migrations
{
    public partial class db1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Okuls",
                columns: table => new
                {
                    OkulID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OkulAd = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Okuls", x => x.OkulID);
                });

            migrationBuilder.CreateTable(
                name: "Yoneticis",
                columns: table => new
                {
                    YoneticiID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    YoneticiAd = table.Column<string>(type: "text", nullable: false),
                    YoneticiSoyad = table.Column<string>(type: "text", nullable: false),
                    MudurMu = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yoneticis", x => x.YoneticiID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Okuls");

            migrationBuilder.DropTable(
                name: "Yoneticis");
        }
    }
}
