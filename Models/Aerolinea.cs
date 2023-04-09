using System.ComponentModel.DataAnnotations;

namespace VuelosCRUD.Models
{
    public class Aerolinea
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 100)]
        public string? Name { get; set; }

        [StringLength(maximumLength: 15)]
        public string? Iata { get; set; }

        [StringLength(maximumLength: 15)]
        public string? Icao { get; set; }






    }
}
