using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConciertos.Migrations
{
    /// <inheritdoc />
    public partial class MiPrimeraChamba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    id_evento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre_evento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_evento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    artista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.id_evento);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
