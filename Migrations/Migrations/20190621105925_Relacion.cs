using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations.Migrations
{
    public partial class Relacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BandId",
                table: "Albums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_BandId",
                table: "Albums",
                column: "BandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Bands_BandId",
                table: "Albums",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Bands_BandId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_BandId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "BandId",
                table: "Albums");
        }
    }
}
