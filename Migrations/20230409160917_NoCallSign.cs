using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuelosCRUD.Migrations
{
    /// <inheritdoc />
    public partial class NoCallSign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallSign",
                table: "Aerolineas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CallSign",
                table: "Aerolineas",
                type: "varchar(35)",
                maxLength: 35,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
