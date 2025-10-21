using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LavanderiaAPI.Migrations
{
    /// <inheritdoc />
    public partial class tablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ACuenta",
                table: "Pedidos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Kilos",
                table: "Pedidos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "MetodoPago",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ACuenta",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Kilos",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "MetodoPago",
                table: "Pedidos");
        }
    }
}
