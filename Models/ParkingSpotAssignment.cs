namespace projecto_bases_de_datos_api.Models
{
    public class ParkingSpotAssignment
    {
        public int ParkingSpotAssignmentID { get; set; }
        public int ParkingSpotID { get; set; }
        public int UserID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Navigation properties
        public ParkingSpot ParkingSpot { get; set; }
        public User User { get; set; }
    }

}
