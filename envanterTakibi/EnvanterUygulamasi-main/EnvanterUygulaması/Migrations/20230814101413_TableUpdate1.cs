using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvanterUygulaması.Migrations
{
    /// <inheritdoc />
    public partial class TableUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Turu",
                table: "Donanimlar");

            migrationBuilder.AddColumn<int>(
                name: "DonanimAltTuruid",
                table: "Donanimlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DonanimTuruID",
                table: "Donanimlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DonanimTurleri",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonanimAltTuruID = table.Column<int>(type: "int", nullable: false),
                    Durumu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonanimTurleri", x => x.id);
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
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_DonanimAltTuruid",
                table: "Donanimlar",
                column: "DonanimAltTuruid");

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_DonanimTuruID",
                table: "Donanimlar",
                column: "DonanimTuruID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonanimAltTurleri_DonanimTuruID",
                table: "DonanimAltTurleri",
                column: "DonanimTuruID");

            migrationBuilder.AddForeignKey(
                name: "FK_Donanimlar_DonanimAltTurleri_DonanimAltTuruid",
                table: "Donanimlar",
                column: "DonanimAltTuruid",
                principalTable: "DonanimAltTurleri",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donanimlar_DonanimTurleri_DonanimTuruID",
                table: "Donanimlar",
                column: "DonanimTuruID",
                principalTable: "DonanimTurleri",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donanimlar_DonanimAltTurleri_DonanimAltTuruid",
                table: "Donanimlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Donanimlar_DonanimTurleri_DonanimTuruID",
                table: "Donanimlar");

            migrationBuilder.DropTable(
                name: "DonanimAltTurleri");

            migrationBuilder.DropTable(
                name: "DonanimTurleri");

            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_DonanimAltTuruid",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_DonanimTuruID",
                table: "Donanimlar");

            migrationBuilder.DropColumn(
                name: "DonanimAltTuruid",
                table: "Donanimlar");

            migrationBuilder.DropColumn(
                name: "DonanimTuruID",
                table: "Donanimlar");

            migrationBuilder.AddColumn<string>(
                name: "Turu",
                table: "Donanimlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
