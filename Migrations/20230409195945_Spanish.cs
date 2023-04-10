using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuelosCRUD.Migrations
{
    /// <inheritdoc />
    public partial class Spanish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Aerolineas_AerolineaId",
                table: "Vuelos");

            migrationBuilder.DropColumn(
                name: "AirlineId",
                table: "Vuelos");

            migrationBuilder.RenameColumn(
                name: "FlightNumber",
                table: "Vuelos",
                newName: "NumeroDeVuelo");

            migrationBuilder.RenameColumn(
                name: "Delayed",
                table: "Vuelos",
                newName: "Demorado");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Aerolineas",
                newName: "Nombre");

            migrationBuilder.AlterColumn<short>(
                name: "AerolineaId",
                table: "Vuelos",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Aerolineas_AerolineaId",
                table: "Vuelos",
                column: "AerolineaId",
                principalTable: "Aerolineas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Aerolineas_AerolineaId",
                table: "Vuelos");

            migrationBuilder.RenameColumn(
                name: "NumeroDeVuelo",
                table: "Vuelos",
                newName: "FlightNumber");

            migrationBuilder.RenameColumn(
                name: "Demorado",
                table: "Vuelos",
                newName: "Delayed");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Aerolineas",
                newName: "Name");

            migrationBuilder.AlterColumn<short>(
                name: "AerolineaId",
                table: "Vuelos",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<short>(
                name: "AirlineId",
                table: "Vuelos",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Aerolineas_AerolineaId",
                table: "Vuelos",
                column: "AerolineaId",
                principalTable: "Aerolineas",
                principalColumn: "Id");
        }
    }
}
