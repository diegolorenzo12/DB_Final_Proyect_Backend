namespace projecto_bases_de_datos_api.Models.DTO
{
    public class CreateVehicleDTO
    {
        public string Type { get; set; } // Auto, Motocicleta
        public string Model { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public int UserID { get; set; }
    }

}
