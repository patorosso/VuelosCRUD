using System.ComponentModel.DataAnnotations;

namespace VuelosCRUD.Models
{
    public class Vuelo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 12)]
        public string NumeroDeVuelo { get; set; } = null!;

        public Aerolinea? Aerolinea { get; set; }


        public short AerolineaId { get; set; }

        [Required]
        public bool Demorado { get; set; } = false;

        [Required]
        public DateTime? Horario { get; set; }





    }
}
