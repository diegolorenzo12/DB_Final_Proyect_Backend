namespace projecto_bases_de_datos_api.Models
{
    public class Building
    {
        public int BuildingID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        // Navigation property for related parking spots
        public List<ParkingSpot> ParkingSpots { get; set; }
    }

}
