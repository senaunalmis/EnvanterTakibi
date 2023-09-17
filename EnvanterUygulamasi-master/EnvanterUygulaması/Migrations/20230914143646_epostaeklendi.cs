using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvanterUygulaması.Migrations
{
    /// <inheritdoc />
    public partial class epostaeklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sifresi",
                table: "Kullanicilar",
                newName: "Soyad");

            migrationBuilder.AddColumn<string>(
                name: "Ad",
                table: "Roller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EklemeTarihi",
                table: "KullaniciRolleri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EklemeTarihi",
                table: "Kullanicilar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Eposta",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ad",
                table: "Roller");

            migrationBuilder.DropColumn(
                name: "EklemeTarihi",
                table: "KullaniciRolleri");

            migrationBuilder.DropColumn(
                name: "EklemeTarihi",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "Eposta",
                table: "Kullanicilar");

            migrationBuilder.RenameColumn(
                name: "Soyad",
                table: "Kullanicilar",
                newName: "Sifresi");
        }
    }
}
