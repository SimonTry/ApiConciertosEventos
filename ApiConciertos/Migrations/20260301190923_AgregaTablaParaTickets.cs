using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConciertos.Migrations
{
    /// <inheritdoc />
    public partial class AgregaTablaParaTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    id_boleta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    valor_unitario = table.Column<double>(type: "float", nullable: false),
                    fecha_compra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numero_boleta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.id_boleta);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
