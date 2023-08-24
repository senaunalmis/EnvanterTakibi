using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvanterUygulaması.Migrations
{
    /// <inheritdoc />
    public partial class talhamig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "DonanimTurleri",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_AltModelID",
                table: "Donanimlar",
                column: "AltModelID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Donanimlar_AltModeller_AltModelID",
                table: "Donanimlar",
                column: "AltModelID",
                principalTable: "AltModeller",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DonanimTurleri",
                newName: "id");
        }
    }
}
