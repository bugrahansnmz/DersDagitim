using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DersDagitimProjesi.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Derss",
                columns: table => new
                {
                    DersID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DersAd = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Derss", x => x.DersID);
                });

            migrationBuilder.CreateTable(
                name: "Ogretmens",
                columns: table => new
                {
                    OgretmenID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OgretmenAd = table.Column<string>(type: "text", nullable: false),
                    OgretmenSoyad = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmens", x => x.OgretmenID);
                });

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

            migrationBuilder.CreateTable(
                name: "Sinifs",
                columns: table => new
                {
                    SinifID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SinifNo = table.Column<int>(type: "integer", nullable: false),
                    SinifSube = table.Column<string>(type: "Char", maxLength: 1, nullable: false),
                    OgrenciSayisi = table.Column<int>(type: "integer", nullable: false),
                    Okulid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinifs", x => x.SinifID);
                    table.ForeignKey(
                        name: "FK_Sinifs_Okuls_Okulid",
                        column: x => x.Okulid,
                        principalTable: "Okuls",
                        principalColumn: "OkulID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ogrencis",
                columns: table => new
                {
                    OgrenciID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OgrenciAd = table.Column<string>(type: "text", nullable: false),
                    OgrenciSoyad = table.Column<string>(type: "text", nullable: false),
                    Sinifid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrencis", x => x.OgrenciID);
                    table.ForeignKey(
                        name: "FK_Ogrencis_Sinifs_Sinifid",
                        column: x => x.Sinifid,
                        principalTable: "Sinifs",
                        principalColumn: "SinifID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Ogrencis_Sinifid",
                table: "Ogrencis",
                column: "Sinifid");

            migrationBuilder.CreateIndex(
                name: "IX_OgretmenSinif_SinifsSinifID",
                table: "OgretmenSinif",
                column: "SinifsSinifID");

            migrationBuilder.CreateIndex(
                name: "IX_Sinifs_Okulid",
                table: "Sinifs",
                column: "Okulid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Derss");

            migrationBuilder.DropTable(
                name: "Ogrencis");

            migrationBuilder.DropTable(
                name: "OgretmenSinif");

            migrationBuilder.DropTable(
                name: "Ogretmens");

            migrationBuilder.DropTable(
                name: "Sinifs");

            migrationBuilder.DropTable(
                name: "Okuls");
        }
    }
}
