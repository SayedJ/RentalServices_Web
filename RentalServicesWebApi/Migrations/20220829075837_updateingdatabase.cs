using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalServicesWebApi.Migrations
{
    public partial class updateingdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b39f962-a412-4e84-ab6e-8a0549bdce39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bf71507-423c-44e8-ac4c-5b464946be7b");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "638d33f2-6112-4ab8-82f1-e2d731d1f9e1", "10e4145f-ac79-4dab-88db-334ef002e7b8", "Administrator", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3638e81-12b5-4dac-9f10-cc8cbacbc54b", "ffdc4a64-7f79-4e3f-9838-85c15ecdbce3", "User", "Customer" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "BoughtDate",
                value: new DateTime(2022, 8, 29, 9, 58, 37, 50, DateTimeKind.Local).AddTicks(2600));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "638d33f2-6112-4ab8-82f1-e2d731d1f9e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3638e81-12b5-4dac-9f10-cc8cbacbc54b");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

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
    }
}
