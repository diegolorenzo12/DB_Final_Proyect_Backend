namespace projecto_bases_de_datos_api.Models
{
    public class ParkingRecord
    {
        public int ParkingRecordID { get; set; }
        public int ParkingSpotID { get; set; }
        public int UserID { get; set; }
        public int VehicleID { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; } // Nullable for ongoing parking

        // Navigation properties
        public ParkingSpot ParkingSpot { get; set; }
        public User User { get; set; }
        public Vehicle Vehicle { get; set; }
    }

}
