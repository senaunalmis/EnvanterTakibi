using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvanterUygulaması.Migrations
{
    /// <inheritdoc />
    public partial class BolgelerTablosu_Eklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birim",
                table: "Yazilimlar");

            migrationBuilder.DropColumn(
                name: "Birim",
                table: "Donanimlar");

            migrationBuilder.DropColumn(
                name: "Bolge",
                table: "Devreler");

            migrationBuilder.AddColumn<int>(
                name: "BolgeId",
                table: "Yazilimlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BolgeId",
                table: "Donanimlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BolgeId",
                table: "Devreler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bolgeler",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolgeler", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Yazilimlar_BolgeId",
                table: "Yazilimlar",
                column: "BolgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Donanimlar_BolgeId",
                table: "Donanimlar",
                column: "BolgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Devreler_BolgeId",
                table: "Devreler",
                column: "BolgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devreler_Bolgeler_BolgeId",
                table: "Devreler",
                column: "BolgeId",
                principalTable: "Bolgeler",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donanimlar_Bolgeler_BolgeId",
                table: "Donanimlar",
                column: "BolgeId",
                principalTable: "Bolgeler",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Yazilimlar_Bolgeler_BolgeId",
                table: "Yazilimlar",
                column: "BolgeId",
                principalTable: "Bolgeler",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devreler_Bolgeler_BolgeId",
                table: "Devreler");

            migrationBuilder.DropForeignKey(
                name: "FK_Donanimlar_Bolgeler_BolgeId",
                table: "Donanimlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Yazilimlar_Bolgeler_BolgeId",
                table: "Yazilimlar");

            migrationBuilder.DropTable(
                name: "Bolgeler");

            migrationBuilder.DropIndex(
                name: "IX_Yazilimlar_BolgeId",
                table: "Yazilimlar");

            migrationBuilder.DropIndex(
                name: "IX_Donanimlar_BolgeId",
                table: "Donanimlar");

            migrationBuilder.DropIndex(
                name: "IX_Devreler_BolgeId",
                table: "Devreler");

            migrationBuilder.DropColumn(
                name: "BolgeId",
                table: "Yazilimlar");

            migrationBuilder.DropColumn(
                name: "BolgeId",
                table: "Donanimlar");

            migrationBuilder.DropColumn(
                name: "BolgeId",
                table: "Devreler");

            migrationBuilder.AddColumn<string>(
                name: "Birim",
                table: "Yazilimlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Birim",
                table: "Donanimlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bolge",
                table: "Devreler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
