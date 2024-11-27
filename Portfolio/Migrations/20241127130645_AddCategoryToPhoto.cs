using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Blogs_BlogId1",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_BlogId1",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "BlogId1",
                table: "Photos");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Photos");

            migrationBuilder.AddColumn<int>(
                name: "BlogId1",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_BlogId1",
                table: "Photos",
                column: "BlogId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Blogs_BlogId1",
                table: "Photos",
                column: "BlogId1",
                principalTable: "Blogs",
                principalColumn: "BlogId");
        }
    }
}
