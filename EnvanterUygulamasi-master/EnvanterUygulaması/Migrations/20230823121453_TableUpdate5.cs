using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvanterUygulaması.Migrations
{
    /// <inheritdoc />
    public partial class TableUpdate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_DonanimAltTuruID",
                table: "Donanimlar");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Donanimlar_AltModeller_AltModelID",
                table: "Donanimlar",
                column: "AltModelID",
                principalTable: "AltModeller",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donanimlar_AltModeller_AltModelID",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_AltModelID",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_DonanimAltTuruID",
                table: "Donanimlar");

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_DonanimAltTuruID",
                table: "Donanimlar",
                column: "DonanimAltTuruID");
        }
    }
}
