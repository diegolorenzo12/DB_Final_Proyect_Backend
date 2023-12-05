namespace projecto_bases_de_datos_api.Models.DTO
{
    public class CreateUserDTO
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public int BuildingID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }


}
