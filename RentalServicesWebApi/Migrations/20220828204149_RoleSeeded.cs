using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalServicesWebApi.Migrations
{
    public partial class RoleSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a449beb-e8a5-4da6-8659-6c2138ccd6e4", "c2261036-bdd5-4e62-980d-f1231e6d9411", "User", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f4ab1ef2-76ea-4c7f-b32d-5c3717d38241", "b5ec543f-c791-4f8f-8721-e6b4444aeeb9", "Administrator", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "BoughtDate",
                value: new DateTime(2022, 8, 28, 22, 41, 49, 436, DateTimeKind.Local).AddTicks(6720));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a449beb-e8a5-4da6-8659-6c2138ccd6e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4ab1ef2-76ea-4c7f-b32d-5c3717d38241");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "BoughtDate",
                value: new DateTime(2022, 8, 28, 22, 32, 3, 510, DateTimeKind.Local).AddTicks(2030));
        }
    }
}
