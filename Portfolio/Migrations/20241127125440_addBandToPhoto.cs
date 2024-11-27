using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class addBandToPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BandId",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlogId1",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_BandId",
                table: "Photos",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_BlogId1",
                table: "Photos",
                column: "BlogId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Bands_BandId",
                table: "Photos",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "BandId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Blogs_BlogId1",
                table: "Photos",
                column: "BlogId1",
                principalTable: "Blogs",
                principalColumn: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Bands_BandId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Blogs_BlogId1",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_BandId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_BlogId1",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "BandId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "BlogId1",
                table: "Photos");
        }
    }
}
