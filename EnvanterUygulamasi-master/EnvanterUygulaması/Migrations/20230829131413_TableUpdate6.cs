using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvanterUygulaması.Migrations
{
    /// <inheritdoc />
    public partial class TableUpdate6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CihazSayisi",
                table: "Yazilimlar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DonanimMarkaId",
                table: "UstModeller",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Durumu",
                table: "Devreler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateIndex(
                name: "IX_UstModeller_DonanimMarkaId",
                table: "UstModeller",
                column: "DonanimMarkaId");

            migrationBuilder.AddForeignKey(
                name: "FK_UstModeller_DonanimMarkalari_DonanimMarkaId",
                table: "UstModeller",
                column: "DonanimMarkaId",
                principalTable: "DonanimMarkalari",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UstModeller_DonanimMarkalari_DonanimMarkaId",
                table: "UstModeller");

            migrationBuilder.DropIndex(
                name: "IX_UstModeller_DonanimMarkaId",
                table: "UstModeller");

            migrationBuilder.DropColumn(
                name: "DonanimMarkaId",
                table: "UstModeller");

            migrationBuilder.AlterColumn<int>(
                name: "CihazSayisi",
                table: "Yazilimlar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "Durumu",
                table: "Devreler",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
