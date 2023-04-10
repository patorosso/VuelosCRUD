using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using VuelosCRUD.Models;

#nullable disable

namespace VuelosCRUD.Migrations
{
    /// <inheritdoc />
    public partial class jsonAirlineDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "../../../Migrations/airlineDB/airline.json";
            var json = File.ReadAllText(@path);

            var aerolineas = JsonConvert.DeserializeObject<List<Aerolinea>>(json);

            foreach (var aerolinea in aerolineas)
            {
                migrationBuilder.InsertData(
                    table: "Aerolineas",
                    columns: new[] { "Id", "Nombre", "Iata", "Icao" },
                    values: new object[] { aerolinea.Id, aerolinea.Nombre, aerolinea.Iata, aerolinea.Icao }
                );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Aerolineas", true);
        }
    }
}


