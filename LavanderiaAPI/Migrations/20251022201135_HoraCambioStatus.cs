using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LavanderiaAPI.Migrations
{
    /// <inheritdoc />
    public partial class HoraCambioStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCambioEstado",
                table: "Pedidos",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCambioEstado",
                table: "Pedidos");
        }
    }
}
