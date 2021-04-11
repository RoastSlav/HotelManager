using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace HotelManager.Migrations.HotelManagerDb
{
    public partial class hotelmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    reservationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    creatingUserId = table.Column<string>(nullable: false),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    LeavingDate = table.Column<DateTime>(nullable: false),
                    IncludedBreakfast = table.Column<bool>(nullable: false),
                    AllInclusive = table.Column<bool>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.reservationId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    clientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Adult = table.Column<bool>(nullable: false, defaultValue: true),
                    CurrentReservatonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.clientId);
                    table.ForeignKey(
                        name: "FK_Clients_Reservations_CurrentReservatonId",
                        column: x => x.CurrentReservatonId,
                        principalTable: "Reservations",
                        principalColumn: "reservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    RoomType = table.Column<string>(nullable: false),
                    Vacant = table.Column<bool>(nullable: false, defaultValue: true),
                    PriceForAdult = table.Column<decimal>(nullable: false),
                    PriceForNonAdult = table.Column<decimal>(nullable: false),
                    CurrentReservatonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Reservations_CurrentReservatonId",
                        column: x => x.CurrentReservatonId,
                        principalTable: "Reservations",
                        principalColumn: "reservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CurrentReservatonId",
                table: "Clients",
                column: "CurrentReservatonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CurrentReservatonId",
                table: "Rooms",
                column: "CurrentReservatonId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
