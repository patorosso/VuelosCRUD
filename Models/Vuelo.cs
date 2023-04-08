namespace VuelosCRUD.Models
{
    public class Vuelo
    {
        public int Id { get; set; }

        public string FlightNumber { get; set; } = null!;

        public string Airline { get; set; } = null!;

        public bool Delayed { get; set; } = false;





    }
}
