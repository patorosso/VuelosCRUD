using System.ComponentModel.DataAnnotations;

namespace VuelosCRUD.Models
{
    public class Vuelo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 12)]
        public string FlightNumber { get; set; } = null!;

        public Aerolinea? Aerolinea { get; set; }

        [Required]
        public byte AirlineId { get; set; }

        [Required]
        public bool Delayed { get; set; } = false;





    }
}
