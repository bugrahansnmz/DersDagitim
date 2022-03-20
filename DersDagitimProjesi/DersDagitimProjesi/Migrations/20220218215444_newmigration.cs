using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DersDagitimProjesi.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ogretmens_Sinifs_Sinifid",
                table: "Ogretmens");

            migrationBuilder.DropIndex(
                name: "IX_Ogretmens_Sinifid",
                table: "Ogretmens");

            migrationBuilder.DropColumn(
                name: "Sinifid",
                table: "Ogretmens");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sinifid",
                table: "Ogretmens",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ogretmens_Sinifid",
                table: "Ogretmens",
                column: "Sinifid");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogretmens_Sinifs_Sinifid",
                table: "Ogretmens",
                column: "Sinifid",
                principalTable: "Sinifs",
                principalColumn: "SinifID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
