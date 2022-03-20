using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DersDagitimProjesi.Migrations
{
    public partial class sonuncu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OgretmenSinif");

            migrationBuilder.AddColumn<int>(
                name: "Dersid",
                table: "Ogretmens",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sinifid",
                table: "Ogretmens",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DersSinif",
                columns: table => new
                {
                    DerssDersID = table.Column<int>(type: "integer", nullable: false),
                    SinifsSinifID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersSinif", x => new { x.DerssDersID, x.SinifsSinifID });
                    table.ForeignKey(
                        name: "FK_DersSinif_Derss_DerssDersID",
                        column: x => x.DerssDersID,
                        principalTable: "Derss",
                        principalColumn: "DersID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DersSinif_Sinifs_SinifsSinifID",
                        column: x => x.SinifsSinifID,
                        principalTable: "Sinifs",
                        principalColumn: "SinifID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guns",
                columns: table => new
                {
                    GunID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GunAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guns", x => x.GunID);
                });

            migrationBuilder.CreateTable(
                name: "Saats",
                columns: table => new
                {
                    SaatID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SaatKac = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saats", x => x.SaatID);
                });

            migrationBuilder.CreateTable(
                name: "DersPrograms",
                columns: table => new
                {
                    ProgramID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sinifid = table.Column<int>(type: "integer", nullable: false),
                    Gunid = table.Column<int>(type: "integer", nullable: false),
                    Dersid = table.Column<int>(type: "integer", nullable: false),
                    Saatid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersPrograms", x => x.ProgramID);
                    table.ForeignKey(
                        name: "FK_DersPrograms_Derss_Dersid",
                        column: x => x.Dersid,
                        principalTable: "Derss",
                        principalColumn: "DersID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DersPrograms_Guns_Gunid",
                        column: x => x.Gunid,
                        principalTable: "Guns",
                        principalColumn: "GunID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DersPrograms_Saats_Saatid",
                        column: x => x.Saatid,
                        principalTable: "Saats",
                        principalColumn: "SaatID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DersPrograms_Sinifs_Sinifid",
                        column: x => x.Sinifid,
                        principalTable: "Sinifs",
                        principalColumn: "SinifID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ogretmens_Dersid",
                table: "Ogretmens",
                column: "Dersid");

            migrationBuilder.CreateIndex(
                name: "IX_Ogretmens_Sinifid",
                table: "Ogretmens",
                column: "Sinifid");

            migrationBuilder.CreateIndex(
                name: "IX_DersPrograms_Dersid",
                table: "DersPrograms",
                column: "Dersid");

            migrationBuilder.CreateIndex(
                name: "IX_DersPrograms_Gunid",
                table: "DersPrograms",
                column: "Gunid");

            migrationBuilder.CreateIndex(
                name: "IX_DersPrograms_Saatid",
                table: "DersPrograms",
                column: "Saatid");

            migrationBuilder.CreateIndex(
                name: "IX_DersPrograms_Sinifid",
                table: "DersPrograms",
                column: "Sinifid");

            migrationBuilder.CreateIndex(
                name: "IX_DersSinif_SinifsSinifID",
                table: "DersSinif",
                column: "SinifsSinifID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogretmens_Derss_Dersid",
                table: "Ogretmens",
                column: "Dersid",
                principalTable: "Derss",
                principalColumn: "DersID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ogretmens_Sinifs_Sinifid",
                table: "Ogretmens",
                column: "Sinifid",
                principalTable: "Sinifs",
                principalColumn: "SinifID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ogretmens_Derss_Dersid",
                table: "Ogretmens");

            migrationBuilder.DropForeignKey(
                name: "FK_Ogretmens_Sinifs_Sinifid",
                table: "Ogretmens");

            migrationBuilder.DropTable(
                name: "DersPrograms");

            migrationBuilder.DropTable(
                name: "DersSinif");

            migrationBuilder.DropTable(
                name: "Guns");

            migrationBuilder.DropTable(
                name: "Saats");

            migrationBuilder.DropIndex(
                name: "IX_Ogretmens_Dersid",
                table: "Ogretmens");

            migrationBuilder.DropIndex(
                name: "IX_Ogretmens_Sinifid",
                table: "Ogretmens");

            migrationBuilder.DropColumn(
                name: "Dersid",
                table: "Ogretmens");

            migrationBuilder.DropColumn(
                name: "Sinifid",
                table: "Ogretmens");

            migrationBuilder.CreateTable(
                name: "OgretmenSinif",
                columns: table => new
                {
                    OgretmensOgretmenID = table.Column<int>(type: "integer", nullable: false),
                    SinifsSinifID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgretmenSinif", x => new { x.OgretmensOgretmenID, x.SinifsSinifID });
                    table.ForeignKey(
                        name: "FK_OgretmenSinif_Ogretmens_OgretmensOgretmenID",
                        column: x => x.OgretmensOgretmenID,
                        principalTable: "Ogretmens",
                        principalColumn: "OgretmenID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgretmenSinif_Sinifs_SinifsSinifID",
                        column: x => x.SinifsSinifID,
                        principalTable: "Sinifs",
                        principalColumn: "SinifID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OgretmenSinif_SinifsSinifID",
                table: "OgretmenSinif",
                column: "SinifsSinifID");
        }
    }
}
