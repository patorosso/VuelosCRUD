using System.ComponentModel.DataAnnotations;

namespace VuelosCRUD.Dtos
{
    public class VueloDto
    {
        public byte Id { get; set; }

        [Required]
        public string NumeroDeVuelo { get; set; } = null!;


        public short AerolineaId { get; set; }


        public AerolineaDto? Aerolinea { get; set; }

        [Required]
        public bool Demorado { get; set; } = false;

        [Required]
        public DateTime? Horario { get; set; }
    }
}
