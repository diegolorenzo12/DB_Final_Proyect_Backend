using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projecto_bases_de_datos_api.Models.DTO;
using projecto_bases_de_datos_api.Models;


namespace projecto_bases_de_datos_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            return await _context.Vehicles.ToListAsync();
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }

        // POST: api/Vehicles
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(CreateVehicleDTO vehicleDTO)
        {
            var vehicle = new Vehicle
            {
                Type = vehicleDTO.Type,
                Model = vehicleDTO.Model,
                Color = vehicleDTO.Color,
                LicensePlate = vehicleDTO.LicensePlate,
                UserID = vehicleDTO.UserID
            };

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicle", new { id = vehicle.VehicleID }, vehicle);
        }

        // PUT: api/Vehicles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, UpdateVehicleDTO vehicleDTO)
        {

            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            vehicle.Type = vehicleDTO.Type;
            vehicle.Model = vehicleDTO.Model;
            vehicle.Color = vehicleDTO.Color;
            vehicle.LicensePlate = vehicleDTO.LicensePlate;

            _context.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.VehicleID == id);
        }
    }

}
