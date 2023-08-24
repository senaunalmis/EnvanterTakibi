using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvanterUygulaması.Migrations
{
    /// <inheritdoc />
    public partial class TableUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EkleyenID",
                table: "Yazilimlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EkleyenID",
                table: "Donanimlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EkleyenID",
                table: "Devreler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Yazilimlar_EkleyenID",
                table: "Yazilimlar",
                column: "EkleyenID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_EkleyenID",
                table: "Donanimlar",
                column: "EkleyenID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devreler_EkleyenID",
                table: "Devreler",
                column: "EkleyenID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Devreler_Kullanicilar_EkleyenID",
                table: "Devreler",
                column: "EkleyenID",
                principalTable: "Kullanicilar",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donanimlar_Kullanicilar_EkleyenID",
                table: "Donanimlar",
                column: "EkleyenID",
                principalTable: "Kullanicilar",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Yazilimlar_Kullanicilar_EkleyenID",
                table: "Yazilimlar",
                column: "EkleyenID",
                principalTable: "Kullanicilar",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devreler_Kullanicilar_EkleyenID",
                table: "Devreler");

            migrationBuilder.DropForeignKey(
                name: "FK_Donanimlar_Kullanicilar_EkleyenID",
                table: "Donanimlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Yazilimlar_Kullanicilar_EkleyenID",
                table: "Yazilimlar");

            migrationBuilder.DropIndex(
                name: "IX_Yazilimlar_EkleyenID",
                table: "Yazilimlar");

            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_EkleyenID",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Devreler_EkleyenID",
                table: "Devreler");

            migrationBuilder.DropColumn(
                name: "EkleyenID",
                table: "Yazilimlar");

            migrationBuilder.DropColumn(
                name: "EkleyenID",
                table: "Donanimlar");

            migrationBuilder.DropColumn(
                name: "EkleyenID",
                table: "Devreler");
        }
    }
}
