using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LavanderiaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ThirdCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResumenesSemanales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemanaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SemanaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalIngresos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalGastos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PedidosCompletados = table.Column<int>(type: "int", nullable: false),
                    PagosRealizados = table.Column<int>(type: "int", nullable: false),
                    FechaGeneracion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumenesSemanales", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResumenesSemanales");
        }
    }
}
