using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("647ad00f-8df6-473d-83bb-7462b8083dc1"), "Hard" },
                    { new Guid("6782b3bb-97ac-401c-9af0-23be8f8b4a12"), "Easy" },
                    { new Guid("970543e6-4357-4a54-99e5-a9bd00810fbb"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("87cc682e-5889-4856-ae98-2c7c3f072304"), "WKO", "Waikato", "https://example.com/images/waikato.jpg" },
                    { new Guid("94856d92-e4b1-4866-8bb6-9c06b8f7f021"), "AKL", "Auckland", "https://example.com/images/auckland.jpg" },
                    { new Guid("ebdcfdce-ab1a-4c35-bb6e-1b52f717b9d9"), "NTL", "Northland", "https://example.com/images/northland.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("647ad00f-8df6-473d-83bb-7462b8083dc1"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6782b3bb-97ac-401c-9af0-23be8f8b4a12"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("970543e6-4357-4a54-99e5-a9bd00810fbb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("87cc682e-5889-4856-ae98-2c7c3f072304"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("94856d92-e4b1-4866-8bb6-9c06b8f7f021"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ebdcfdce-ab1a-4c35-bb6e-1b52f717b9d9"));
        }
    }
}
