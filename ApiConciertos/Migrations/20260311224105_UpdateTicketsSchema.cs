using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConciertos.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTicketsSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EventoId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "NroAsiento",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ticketStatus",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ClienteId",
                table: "Tickets",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventoId",
                table: "Tickets",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Clients_ClienteId",
                table: "Tickets",
                column: "ClienteId",
                principalTable: "Clients",
                principalColumn: "Cliente_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Events_EventoId",
                table: "Tickets",
                column: "EventoId",
                principalTable: "Events",
                principalColumn: "id_evento",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Clients_ClienteId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Events_EventoId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ClienteId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EventoId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "NroAsiento",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ticketStatus",
                table: "Tickets");
        }
    }
}
