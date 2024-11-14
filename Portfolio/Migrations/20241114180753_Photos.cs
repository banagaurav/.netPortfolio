using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class Photos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.AlbumId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "BlogDescription", "DisplayOrder", "Image", "Title" },
                values: new object[,]
                {
                    { 1, "textarea", 1, "img1", "Action" },
                    { 2, "textarea", 2, "img2", "Scifie" },
                    { 3, "textarea", 3, "img3", "History" }
                });
        }
    }
}
