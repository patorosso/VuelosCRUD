using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuelosCRUD.Migrations
{
    /// <inheritdoc />
    public partial class shortValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Airline",
                table: "Vuelos");

            migrationBuilder.AddColumn<short>(
                name: "AerolineaId",
                table: "Vuelos",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "AirlineId",
                table: "Vuelos",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AlterColumn<short>(
                name: "Id",
                table: "Aerolineas",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_AerolineaId",
                table: "Vuelos",
                column: "AerolineaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Aerolineas_AerolineaId",
                table: "Vuelos",
                column: "AerolineaId",
                principalTable: "Aerolineas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Aerolineas_AerolineaId",
                table: "Vuelos");

            migrationBuilder.DropIndex(
                name: "IX_Vuelos_AerolineaId",
                table: "Vuelos");

            migrationBuilder.DropColumn(
                name: "AerolineaId",
                table: "Vuelos");

            migrationBuilder.DropColumn(
                name: "AirlineId",
                table: "Vuelos");

            migrationBuilder.AddColumn<string>(
                name: "Airline",
                table: "Vuelos",
                type: "varchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Aerolineas",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }
    }
}
