using static System.Runtime.InteropServices.JavaScript.JSType;

namespace projecto_bases_de_datos_api.Models
{

    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; } // Alumno, Docente, Administrativo, Invitado
        public int BuildingID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Add this line
        public List<Vehicle> Vehicles { get; set; } // Navigation property for related vehicles

        public List<ParkingSpotAssignment> ParkingSpotAssignments { get; set; } // Navigation property for related parking spots assignments
    }



}
