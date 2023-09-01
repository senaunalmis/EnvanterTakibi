using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvanterUygulaması.Migrations
{
    /// <inheritdoc />
    public partial class Database_Config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donanimlar_AltModeller_AltModelID",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Yazilimlar_EkleyenID",
                table: "Yazilimlar");

            migrationBuilder.DropIndex(
                name: "IX_Yazilimlar_YazilimMarkaID",
                table: "Yazilimlar");

            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_AltModelID",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_DonanimAltTuruID",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_DonanimMarkaID",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_DonanimTuruID",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_EkleyenID",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_UstModelID",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Devreler_BulutID",
                table: "Devreler");

            migrationBuilder.DropIndex(
                name: "IX_Devreler_EkleyenID",
                table: "Devreler");

            migrationBuilder.CreateIndex(
                name: "IX_Yazilimlar_EkleyenID",
                table: "Yazilimlar",
                column: "EkleyenID");

            migrationBuilder.CreateIndex(
                name: "IX_Yazilimlar_YazilimMarkaID",
                table: "Yazilimlar",
                column: "YazilimMarkaID");

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
                name: "IX_Devreler_BulutID",
                table: "Devreler",
                column: "BulutID");

            migrationBuilder.CreateIndex(
                name: "IX_Devreler_EkleyenID",
                table: "Devreler",
                column: "EkleyenID");

            migrationBuilder.AddForeignKey(
                name: "FK_Donanimlar_AltModeller_AltModelID",
                table: "Donanimlar",
                column: "AltModelID",
                principalTable: "AltModeller",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donanimlar_AltModeller_AltModelID",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Yazilimlar_EkleyenID",
                table: "Yazilimlar");

            migrationBuilder.DropIndex(
                name: "IX_Yazilimlar_YazilimMarkaID",
                table: "Yazilimlar");

            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_AltModelID",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_DonanimAltTuruID",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_DonanimMarkaID",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_DonanimTuruID",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_EkleyenID",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_UstModelID",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Devreler_BulutID",
                table: "Devreler");

            migrationBuilder.DropIndex(
                name: "IX_Devreler_EkleyenID",
                table: "Devreler");

            migrationBuilder.CreateIndex(
                name: "IX_Yazilimlar_EkleyenID",
                table: "Yazilimlar",
                column: "EkleyenID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yazilimlar_YazilimMarkaID",
                table: "Yazilimlar",
                column: "YazilimMarkaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_AltModelID",
                table: "Donanimlar",
                column: "AltModelID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_DonanimAltTuruID",
                table: "Donanimlar",
                column: "DonanimAltTuruID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_DonanimMarkaID",
                table: "Donanimlar",
                column: "DonanimMarkaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_DonanimTuruID",
                table: "Donanimlar",
                column: "DonanimTuruID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_EkleyenID",
                table: "Donanimlar",
                column: "EkleyenID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_UstModelID",
                table: "Donanimlar",
                column: "UstModelID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devreler_BulutID",
                table: "Devreler",
                column: "BulutID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devreler_EkleyenID",
                table: "Devreler",
                column: "EkleyenID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Donanimlar_AltModeller_AltModelID",
                table: "Donanimlar",
                column: "AltModelID",
                principalTable: "AltModeller",
                principalColumn: "id");
        }
    }
}
