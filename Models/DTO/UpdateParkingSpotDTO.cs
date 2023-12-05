namespace projecto_bases_de_datos_api.Models.DTO
{
    public class UpdateParkingSpotDTO
    {
        public string Location { get; set; }
        public bool IsOccupied { get; set; }
        public string Type { get; set; }
        public int BuildingID { get; set; }
    }

}
