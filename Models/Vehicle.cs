namespace projecto_bases_de_datos_api.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string Type { get; set; } // Auto, Motocicleta
        public string Model { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public int UserID { get; set; }

        // Navigation property
        public User User { get; set; }
    }

}
