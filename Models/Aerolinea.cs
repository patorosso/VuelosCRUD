namespace VuelosCRUD.Models
{
    public class Aerolinea
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Iata { get; set; }

        public string? Icao { get; set; }

        public string? CallSign { get; set; }

        public string? Country { get; set; }

        public bool Active { get; set; }


    }
}
