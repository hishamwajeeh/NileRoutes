using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NileRoutes.Migrations
{
    /// <inheritdoc />
    public partial class seedingDataForDifficultyandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("594f967b-b050-4cd5-a244-5c76a94c09bb"), "Medium" },
                    { new Guid("62e23720-f44c-4984-86cc-015f32be0ca1"), "Hard" },
                    { new Guid("f1b4532c-2bd0-417d-aebc-08c3661d09e5"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("2b902116-dceb-4c77-a982-bd4f3bd6baae"), 101, "Cairo", "https://www.presidency.eg/media/99953/%D8%A7%D9%84%D8%B7%D8%B1%D9%8A%D9%82-%D8%A7%D9%84%D8%AF%D8%A7%D8%A6%D8%B1%D9%89-%D8%A7%D9%84%D8%A3%D9%88%D8%B3%D8%B7%D9%89-%D9%85%D9%86-%D8%B7%D8%B1%D9%8A%D9%82-%D8%A8%D9%84%D8%A8%D9%8A%D8%B3-%D8%AD%D8%AA%D9%89-%D8%AA%D9%82%D8%A7%D8%B7%D8%B9%D9%87-%D9%85%D8%B9-%D8%B7%D8%B1%D9%8A%D9%82-%D8%A7%D9%84%D9%82%D8%A7%D9%87%D8%B1%D8%A9-%D8%A7%D9%84%D8%B3%D9%88%D9%8A%D8%B3-0jpg.jpg" },
                    { new Guid("8c3e3508-6551-4411-88ce-c3904cfc82b2"), 102, "Alex", "https://nasseryouthmovement.net/uploads/images/2022/05/image_750x_62777178a4830.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("594f967b-b050-4cd5-a244-5c76a94c09bb"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("62e23720-f44c-4984-86cc-015f32be0ca1"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f1b4532c-2bd0-417d-aebc-08c3661d09e5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2b902116-dceb-4c77-a982-bd4f3bd6baae"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8c3e3508-6551-4411-88ce-c3904cfc82b2"));
        }
    }
}
