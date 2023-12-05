namespace projecto_bases_de_datos_api.Models
{
    public class ParkingSpot
    {
        public int ParkingSpotID { get; set; }
        public string Location { get; set; }
        public bool IsOccupied { get; set; }
        public string Type { get; set; } // Reservado/General
        public int BuildingID { get; set; }

        // Navigation properties
        public Building Building { get; set; }
        public List<ParkingSpotAssignment> ParkingSpotAssignments { get; set; }
    }

}
