using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalServicesWebApi.Migrations
{
    public partial class RoleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "BoughtDate",
                value: new DateTime(2022, 8, 28, 22, 32, 3, 510, DateTimeKind.Local).AddTicks(2030));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "BoughtDate",
                value: new DateTime(2022, 8, 28, 22, 28, 33, 670, DateTimeKind.Local).AddTicks(9240));
        }
    }
}
