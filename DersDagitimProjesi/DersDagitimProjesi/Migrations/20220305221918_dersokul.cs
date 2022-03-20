using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DersDagitimProjesi.Migrations
{
    public partial class dersokul : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sinifs_Okuls_Okulid",
                table: "Sinifs");

            migrationBuilder.DropTable(
                name: "Okuls");

            migrationBuilder.DropIndex(
                name: "IX_Sinifs_Okulid",
                table: "Sinifs");

            migrationBuilder.DropColumn(
                name: "Okulid",
                table: "Sinifs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Okulid",
                table: "Sinifs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Okuls",
                columns: table => new
                {
                    OkulID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OkulAdı = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Okuls", x => x.OkulID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sinifs_Okulid",
                table: "Sinifs",
                column: "Okulid");

            migrationBuilder.AddForeignKey(
                name: "FK_Sinifs_Okuls_Okulid",
                table: "Sinifs",
                column: "Okulid",
                principalTable: "Okuls",
                principalColumn: "OkulID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
