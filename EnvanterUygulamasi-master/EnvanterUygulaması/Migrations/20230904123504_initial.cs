using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvanterUygulaması.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bildirimler",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OkunduMu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bildirimler", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Bulutlar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnaDevreNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bulutlar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DonanimMarkalari",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TurID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonanimMarkalari", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DonanimTurleri",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durumu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonanimTurleri", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifresi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Loglar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loglar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yetkisi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "YazilimMarkalari",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durumu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YazilimMarkalari", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UstModeller",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonanimMarkaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UstModeller", x => x.id);
                    table.ForeignKey(
                        name: "FK_UstModeller_DonanimMarkalari_DonanimMarkaId",
                        column: x => x.DonanimMarkaId,
                        principalTable: "DonanimMarkalari",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonanimAltTurleri",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonanimTuruID = table.Column<int>(type: "int", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durumu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonanimAltTurleri", x => x.id);
                    table.ForeignKey(
                        name: "FK_DonanimAltTurleri_DonanimTurleri_DonanimTuruID",
                        column: x => x.DonanimTuruID,
                        principalTable: "DonanimTurleri",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonanimMarkaTurleri",
                columns: table => new
                {
                    TurId = table.Column<int>(type: "int", nullable: false),
                    MarkaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonanimMarkaTurleri", x => new { x.MarkaId, x.TurId });
                    table.ForeignKey(
                        name: "FK_DonanimMarkaTurleri_DonanimMarkalari_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "DonanimMarkalari",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonanimMarkaTurleri_DonanimTurleri_TurId",
                        column: x => x.TurId,
                        principalTable: "DonanimTurleri",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devreler",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    Bolge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BulutID = table.Column<int>(type: "int", nullable: false),
                    IpBlogu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Koordinat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mahsup = table.Column<bool>(type: "bit", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EkleyenID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devreler", x => x.id);
                    table.ForeignKey(
                        name: "FK_Devreler_Bulutlar_BulutID",
                        column: x => x.BulutID,
                        principalTable: "Bulutlar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Devreler_Kullanicilar_EkleyenID",
                        column: x => x.EkleyenID,
                        principalTable: "Kullanicilar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciRolleri",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    RolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciRolleri", x => new { x.KullaniciID, x.RolID });
                    table.ForeignKey(
                        name: "FK_KullaniciRolleri_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciRolleri_Roller_RolID",
                        column: x => x.RolID,
                        principalTable: "Roller",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yazilimlar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YazilimMarkaID = table.Column<int>(type: "int", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Versiyon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Turu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CihazSayisi = table.Column<int>(type: "int", nullable: false),
                    AlimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DestekSuresi = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EkleyenID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazilimlar", x => x.id);
                    table.ForeignKey(
                        name: "FK_Yazilimlar_Kullanicilar_EkleyenID",
                        column: x => x.EkleyenID,
                        principalTable: "Kullanicilar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Yazilimlar_YazilimMarkalari_YazilimMarkaID",
                        column: x => x.YazilimMarkaID,
                        principalTable: "YazilimMarkalari",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AltModeller",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UstModelID = table.Column<int>(type: "int", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durumu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AltModeller", x => x.id);
                    table.ForeignKey(
                        name: "FK_AltModeller_UstModeller_UstModelID",
                        column: x => x.UstModelID,
                        principalTable: "UstModeller",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Donanimlar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonanimTuruID = table.Column<int>(type: "int", nullable: false),
                    DonanimAltTuruID = table.Column<int>(type: "int", nullable: true),
                    DonanimMarkaID = table.Column<int>(type: "int", nullable: false),
                    UstModelID = table.Column<int>(type: "int", nullable: false),
                    AltModelID = table.Column<int>(type: "int", nullable: false),
                    MacAdresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeriNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GarantiSuresi = table.Column<int>(type: "int", nullable: false),
                    Poe = table.Column<bool>(type: "bit", nullable: false),
                    BaglantiHizi = table.Column<int>(type: "int", nullable: true),
                    Modu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gucu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EkleyenID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donanimlar", x => x.id);
                    table.ForeignKey(
                        name: "FK_Donanimlar_AltModeller_AltModelID",
                        column: x => x.AltModelID,
                        principalTable: "AltModeller",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donanimlar_DonanimAltTurleri_DonanimAltTuruID",
                        column: x => x.DonanimAltTuruID,
                        principalTable: "DonanimAltTurleri",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Donanimlar_DonanimMarkalari_DonanimMarkaID",
                        column: x => x.DonanimMarkaID,
                        principalTable: "DonanimMarkalari",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donanimlar_DonanimTurleri_DonanimTuruID",
                        column: x => x.DonanimTuruID,
                        principalTable: "DonanimTurleri",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donanimlar_Kullanicilar_EkleyenID",
                        column: x => x.EkleyenID,
                        principalTable: "Kullanicilar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donanimlar_UstModeller_UstModelID",
                        column: x => x.UstModelID,
                        principalTable: "UstModeller",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AltModeller_UstModelID",
                table: "AltModeller",
                column: "UstModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Devreler_BulutID",
                table: "Devreler",
                column: "BulutID");

            migrationBuilder.CreateIndex(
                name: "IX_Devreler_EkleyenID",
                table: "Devreler",
                column: "EkleyenID");

            migrationBuilder.CreateIndex(
                name: "IX_DonanimAltTurleri_DonanimTuruID",
                table: "DonanimAltTurleri",
                column: "DonanimTuruID");

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_AltModelID",
                table: "Donanimlar",
                column: "AltModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_DonanimAltTuruID",
                table: "Donanimlar",
                column: "DonanimAltTuruID");

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_DonanimMarkaID",
                table: "Donanimlar",
                column: "DonanimMarkaID");

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_DonanimTuruID",
                table: "Donanimlar",
                column: "DonanimTuruID");

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_EkleyenID",
                table: "Donanimlar",
                column: "EkleyenID");

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_UstModelID",
                table: "Donanimlar",
                column: "UstModelID");

            migrationBuilder.CreateIndex(
                name: "IX_DonanimMarkaTurleri_TurId",
                table: "DonanimMarkaTurleri",
                column: "TurId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRolleri_RolID",
                table: "KullaniciRolleri",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_UstModeller_DonanimMarkaId",
                table: "UstModeller",
                column: "DonanimMarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Yazilimlar_EkleyenID",
                table: "Yazilimlar",
                column: "EkleyenID");

            migrationBuilder.CreateIndex(
                name: "IX_Yazilimlar_YazilimMarkaID",
                table: "Yazilimlar",
                column: "YazilimMarkaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bildirimler");

            migrationBuilder.DropTable(
                name: "Devreler");

            migrationBuilder.DropTable(
                name: "Donanimlar");

            migrationBuilder.DropTable(
                name: "DonanimMarkaTurleri");

            migrationBuilder.DropTable(
                name: "KullaniciRolleri");

            migrationBuilder.DropTable(
                name: "Loglar");

            migrationBuilder.DropTable(
                name: "Yazilimlar");

            migrationBuilder.DropTable(
                name: "Bulutlar");

            migrationBuilder.DropTable(
                name: "AltModeller");

            migrationBuilder.DropTable(
                name: "DonanimAltTurleri");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "YazilimMarkalari");

            migrationBuilder.DropTable(
                name: "UstModeller");

            migrationBuilder.DropTable(
                name: "DonanimTurleri");

            migrationBuilder.DropTable(
                name: "DonanimMarkalari");
        }
    }
}
