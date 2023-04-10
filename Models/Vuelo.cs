using System.ComponentModel.DataAnnotations;

namespace VuelosCRUD.Models
{
    public class Vuelo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [FlightNumberValidation]
        [StringLength(maximumLength: 12)]
        public string NumeroDeVuelo { get; set; } = null!;

        public Aerolinea? Aerolinea { get; set; }


        public short AerolineaId { get; set; }


        public bool Demorado { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public DateTime? Horario { get; set; }





    }
}
