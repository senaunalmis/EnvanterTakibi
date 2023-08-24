using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvanterUygulaması.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bulutlar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Durumu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonanimMarkalari", x => x.id);
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
                name: "UstModeller",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durumu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UstModeller", x => x.id);
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
                    Durumu = table.Column<bool>(type: "bit", nullable: false),
                    Koordinat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mahsup = table.Column<bool>(type: "bit", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Turu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltBasligi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonanimMarkaID = table.Column<int>(type: "int", nullable: false),
                    UstModelID = table.Column<int>(type: "int", nullable: false),
                    AltModelID = table.Column<int>(type: "int", nullable: false),
                    MacAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GarantiSuresi = table.Column<int>(type: "int", nullable: false),
                    Adedi = table.Column<int>(type: "int", nullable: false),
                    Poe = table.Column<bool>(type: "bit", nullable: false),
                    BaglantiHizi = table.Column<int>(type: "int", nullable: true),
                    Modu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donanimlar", x => x.id);
                    table.ForeignKey(
                        name: "FK_Donanimlar_DonanimMarkalari_DonanimMarkaID",
                        column: x => x.DonanimMarkaID,
                        principalTable: "DonanimMarkalari",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donanimlar_UstModeller_UstModelID",
                        column: x => x.UstModelID,
                        principalTable: "UstModeller",
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
                    CihazSayisi = table.Column<int>(type: "int", nullable: true),
                    AlimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DestekSuresi = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazilimlar", x => x.id);
                    table.ForeignKey(
                        name: "FK_Yazilimlar_YazilimMarkalari_YazilimMarkaID",
                        column: x => x.YazilimMarkaID,
                        principalTable: "YazilimMarkalari",
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
                column: "BulutID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_DonanimMarkaID",
                table: "Donanimlar",
                column: "DonanimMarkaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_UstModelID",
                table: "Donanimlar",
                column: "UstModelID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRolleri_RolID",
                table: "KullaniciRolleri",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_Yazilimlar_YazilimMarkaID",
                table: "Yazilimlar",
                column: "YazilimMarkaID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AltModeller");

            migrationBuilder.DropTable(
                name: "Devreler");

            migrationBuilder.DropTable(
                name: "Donanimlar");

            migrationBuilder.DropTable(
                name: "KullaniciRolleri");

            migrationBuilder.DropTable(
                name: "Yazilimlar");

            migrationBuilder.DropTable(
                name: "Bulutlar");

            migrationBuilder.DropTable(
                name: "DonanimMarkalari");

            migrationBuilder.DropTable(
                name: "UstModeller");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "YazilimMarkalari");
        }
    }
}
