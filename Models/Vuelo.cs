using System.ComponentModel.DataAnnotations;

namespace VuelosCRUD.Models
{
    public class Vuelo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 12)]
        public string FlightNumber { get; set; } = null!;

        [Required]
        [StringLength(maximumLength: 70)]
        public string Airline { get; set; } = null!;

        [Required]
        public bool Delayed { get; set; } = false;





    }
}
