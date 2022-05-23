using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalServicesWebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollectingMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeansOfCollection = table.Column<int>(type: "int", nullable: false),
                    MeetingTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectingMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalSetUps",
                columns: table => new
                {
                    ResId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalSetUps", x => x.ResId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalInfoSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNameId = table.Column<int>(type: "int", nullable: true),
                    Rules = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    CollectingId = table.Column<int>(type: "int", nullable: true),
                    RentingDateInfoResId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalInfoSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalInfoSystems_CollectingMethods_CollectingId",
                        column: x => x.CollectingId,
                        principalTable: "CollectingMethods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RentalInfoSystems_RentalSetUps_RentingDateInfoResId",
                        column: x => x.RentingDateInfoResId,
                        principalTable: "RentalSetUps",
                        principalColumn: "ResId");
                    table.ForeignKey(
                        name: "FK_RentalInfoSystems_Users_UserNameId",
                        column: x => x.UserNameId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalInfoSystemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_RentalInfoSystems_RentalInfoSystemId",
                        column: x => x.RentalInfoSystemId,
                        principalTable: "RentalInfoSystems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ItemId",
                table: "Categories",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_RentalInfoSystemId",
                table: "Items",
                column: "RentalInfoSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalInfoSystems_CollectingId",
                table: "RentalInfoSystems",
                column: "CollectingId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalInfoSystems_RentingDateInfoResId",
                table: "RentalInfoSystems",
                column: "RentingDateInfoResId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalInfoSystems_UserNameId",
                table: "RentalInfoSystems",
                column: "UserNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "RentalInfoSystems");

            migrationBuilder.DropTable(
                name: "CollectingMethods");

            migrationBuilder.DropTable(
                name: "RentalSetUps");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
