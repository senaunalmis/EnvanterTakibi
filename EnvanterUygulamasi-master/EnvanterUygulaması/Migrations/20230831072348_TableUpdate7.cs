using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvanterUygulaması.Migrations
{
    /// <inheritdoc />
    public partial class TableUpdate7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donanimlar_DonanimAltTurleri_DonanimAltTuruID",
                table: "Donanimlar");

            migrationBuilder.AlterColumn<int>(
                name: "DonanimAltTuruID",
                table: "Donanimlar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Gucu",
                table: "Donanimlar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Donanimlar_DonanimAltTurleri_DonanimAltTuruID",
                table: "Donanimlar",
                column: "DonanimAltTuruID",
                principalTable: "DonanimAltTurleri",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donanimlar_DonanimAltTurleri_DonanimAltTuruID",
                table: "Donanimlar");

            migrationBuilder.DropColumn(
                name: "Gucu",
                table: "Donanimlar");

            migrationBuilder.AlterColumn<int>(
                name: "DonanimAltTuruID",
                table: "Donanimlar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Donanimlar_DonanimAltTurleri_DonanimAltTuruID",
                table: "Donanimlar",
                column: "DonanimAltTuruID",
                principalTable: "DonanimAltTurleri",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
