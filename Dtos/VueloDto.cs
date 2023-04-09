using System.ComponentModel.DataAnnotations;

namespace VuelosCRUD.Dtos
{
    public class VueloDto
    {
        public int Id { get; set; }

        [Required]
        public string FlightNumber { get; set; } = null!;

        [Required]
        public string Airline { get; set; } = null!;

        [Required]
        public bool Delayed { get; set; } = false;
    }
}
