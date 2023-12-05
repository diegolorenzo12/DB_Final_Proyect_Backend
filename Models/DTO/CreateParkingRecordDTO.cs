namespace projecto_bases_de_datos_api.Models.DTO
{
    public class CreateParkingRecordDTO
    {
        public int ParkingSpotID { get; set; }
        public int UserID { get; set; }
        public int VehicleID { get; set; }
        public DateTime EntryTime { get; set; }
    }

}
