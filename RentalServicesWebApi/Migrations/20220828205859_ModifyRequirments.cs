using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalServicesWebApi.Migrations
{
    public partial class ModifyRequirments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a449beb-e8a5-4da6-8659-6c2138ccd6e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4ab1ef2-76ea-4c7f-b32d-5c3717d38241");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1b39f962-a412-4e84-ab6e-8a0549bdce39", "58557437-8b06-4dbb-bafb-554fcb1e5a0d", "Administrator", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8bf71507-423c-44e8-ac4c-5b464946be7b", "02fba94c-96b6-4b41-8dcf-2359082d5d65", "User", "Customer" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "BoughtDate",
                value: new DateTime(2022, 8, 28, 22, 58, 59, 328, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b39f962-a412-4e84-ab6e-8a0549bdce39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bf71507-423c-44e8-ac4c-5b464946be7b");

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
    }
}
