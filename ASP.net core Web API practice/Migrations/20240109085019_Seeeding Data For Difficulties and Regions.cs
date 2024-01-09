using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WalkandTrailsofSAAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeeedingDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0b6aa6d4-3066-489e-a8cb-28c3bc73e920"), "Hard" },
                    { new Guid("c12576f9-dbb8-42ac-8c8b-7ac7e1d5c269"), "Easy" },
                    { new Guid("d474c924-8ef8-4dc4-b002-308692b1d379"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("46595a53-78d5-481f-858b-2c674aa6a646"), "GP", "Gauteng", "https://example.com/gauteng_image.jpg" },
                    { new Guid("de08f807-4914-4f76-8fd5-f5ed4dc3b24e"), "KZN", "KwaZulu-Natal", "https://example.com/kwazulu_natal_image.jpg" },
                    { new Guid("fd000ceb-2b33-4e59-a38f-20373e302e03"), "WC", "Western Cape", "https://example.com/western_cape_image.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0b6aa6d4-3066-489e-a8cb-28c3bc73e920"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c12576f9-dbb8-42ac-8c8b-7ac7e1d5c269"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d474c924-8ef8-4dc4-b002-308692b1d379"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("46595a53-78d5-481f-858b-2c674aa6a646"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("de08f807-4914-4f76-8fd5-f5ed4dc3b24e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("fd000ceb-2b33-4e59-a38f-20373e302e03"));
        }
    }
}
