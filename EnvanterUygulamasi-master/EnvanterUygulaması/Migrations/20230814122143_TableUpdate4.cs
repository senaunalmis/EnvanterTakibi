using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvanterUygulaması.Migrations
{
    /// <inheritdoc />
    public partial class TableUpdate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donanimlar_DonanimAltTurleri_DonanimAltTuruid",
                table: "Donanimlar");

            migrationBuilder.DropColumn(
                name: "AltBasligi",
                table: "Donanimlar");

            migrationBuilder.RenameColumn(
                name: "DonanimAltTuruid",
                table: "Donanimlar",
                newName: "DonanimAltTuruID");

            migrationBuilder.RenameIndex(
                name: "IX_Donanimlar_DonanimAltTuruid",
                table: "Donanimlar",
                newName: "IX_Donanimlar_DonanimAltTuruID");

            migrationBuilder.AddForeignKey(
                name: "FK_Donanimlar_DonanimAltTurleri_DonanimAltTuruID",
                table: "Donanimlar",
                column: "DonanimAltTuruID",
                principalTable: "DonanimAltTurleri",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donanimlar_DonanimAltTurleri_DonanimAltTuruID",
                table: "Donanimlar");

            migrationBuilder.RenameColumn(
                name: "DonanimAltTuruID",
                table: "Donanimlar",
                newName: "DonanimAltTuruid");

            migrationBuilder.RenameIndex(
                name: "IX_Donanimlar_DonanimAltTuruID",
                table: "Donanimlar",
                newName: "IX_Donanimlar_DonanimAltTuruid");

            migrationBuilder.AddColumn<string>(
                name: "AltBasligi",
                table: "Donanimlar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Donanimlar_DonanimAltTurleri_DonanimAltTuruid",
                table: "Donanimlar",
                column: "DonanimAltTuruid",
                principalTable: "DonanimAltTurleri",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
