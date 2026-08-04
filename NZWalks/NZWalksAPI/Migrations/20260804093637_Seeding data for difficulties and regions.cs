using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class Seedingdatafordifficultiesandregions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7ac918a2-c35a-49a9-94f1-89d1a8f9a231"), "Easy" },
                    { new Guid("af3694cd-20f7-48a2-840a-573f5cf9cadc"), "Hard" },
                    { new Guid("de147188-f5d5-4862-9806-fe294d3ba562"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "imageUrl" },
                values: new object[,]
                {
                    { new Guid("b9dca3f0-46d4-4f59-af27-5695f765819a"), "Auckland", "Auckland", "https://images.unsplash.com/photo-1506973038032-c6f1e4c8024f?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80" },
                    { new Guid("dadf833b-e873-44ba-b113-f5793d61d379"), "Christchurch", "Christchurch", "https://images.unsplash.com/photo-1506973038032-c6f1e4c8024f?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80" },
                    { new Guid("e94bd608-6325-47f2-a764-299b985f9614"), "Wellington", "Wellington", "https://images.unsplash.com/photo-1506973038032-c6f1e4c8024f?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7ac918a2-c35a-49a9-94f1-89d1a8f9a231"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("af3694cd-20f7-48a2-840a-573f5cf9cadc"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("de147188-f5d5-4862-9806-fe294d3ba562"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b9dca3f0-46d4-4f59-af27-5695f765819a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("dadf833b-e873-44ba-b113-f5793d61d379"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e94bd608-6325-47f2-a764-299b985f9614"));
        }
    }
}
