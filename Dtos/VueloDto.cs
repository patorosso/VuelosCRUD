using System.ComponentModel.DataAnnotations;

namespace VuelosCRUD.Dtos
{
    public class VueloDto
    {
        public byte Id { get; set; }

        [Required]
        public string FlightNumber { get; set; } = null!;

        public byte AerolineaId { get; set; }

        [Required]
        public AerolineaDto Aerolinea { get; set; } = null!;

        [Required]
        public bool Delayed { get; set; } = false;
    }
}
