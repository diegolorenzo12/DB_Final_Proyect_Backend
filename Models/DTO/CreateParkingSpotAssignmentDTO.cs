namespace projecto_bases_de_datos_api.Models.DTO
{
    public class CreateParkingSpotAssignmentDTO
    {
        public int ParkingSpotID { get; set; }
        public int UserID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

}
