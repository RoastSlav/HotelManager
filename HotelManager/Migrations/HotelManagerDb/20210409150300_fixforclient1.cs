using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManager.Migrations.HotelManagerDb
{
    public partial class fixforclient1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Reservations_CurrentReservatonId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Reservations_CurrentReservatonId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CurrentReservatonId",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentReservatonId",
                table: "Rooms",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentReservatonId",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CurrentReservatonId",
                table: "Rooms",
                column: "CurrentReservatonId",
                unique: true,
                filter: "[CurrentReservatonId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Reservations_CurrentReservatonId",
                table: "Clients",
                column: "CurrentReservatonId",
                principalTable: "Reservations",
                principalColumn: "reservationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Reservations_CurrentReservatonId",
                table: "Rooms",
                column: "CurrentReservatonId",
                principalTable: "Reservations",
                principalColumn: "reservationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Reservations_CurrentReservatonId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Reservations_CurrentReservatonId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CurrentReservatonId",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentReservatonId",
                table: "Rooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentReservatonId",
                table: "Clients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CurrentReservatonId",
                table: "Rooms",
                column: "CurrentReservatonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Reservations_CurrentReservatonId",
                table: "Clients",
                column: "CurrentReservatonId",
                principalTable: "Reservations",
                principalColumn: "reservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Reservations_CurrentReservatonId",
                table: "Rooms",
                column: "CurrentReservatonId",
                principalTable: "Reservations",
                principalColumn: "reservationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
