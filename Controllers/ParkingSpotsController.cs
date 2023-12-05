using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projecto_bases_de_datos_api.Models.DTO;
using projecto_bases_de_datos_api.Models;


namespace projecto_bases_de_datos_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSpotsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParkingSpotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ParkingSpots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingSpot>>> GetParkingSpots()
        {
            return await _context.ParkingSpots.ToListAsync();
        }

        // GET: api/ParkingSpots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingSpot>> GetParkingSpot(int id)
        {
            var parkingSpot = await _context.ParkingSpots.FindAsync(id);

            if (parkingSpot == null)
            {
                return NotFound();
            }

            return parkingSpot;
        }

        // PUT: api/ParkingSpots/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParkingSpot(int id, UpdateParkingSpotDTO parkingSpotDTO)
        {

            var parkingSpot = await _context.ParkingSpots.FindAsync(id);
            if (parkingSpot == null)
            {
                return NotFound();
            }

            parkingSpot.Location = parkingSpotDTO.Location;
            parkingSpot.IsOccupied = parkingSpotDTO.IsOccupied;
            parkingSpot.Type = parkingSpotDTO.Type;
            parkingSpot.BuildingID = parkingSpotDTO.BuildingID;

            _context.Entry(parkingSpot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingSpotExists(id))
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

        // POST: api/ParkingSpots
        [HttpPost]
        public async Task<ActionResult<ParkingSpot>> PostParkingSpot(CreateParkingSpotDTO parkingSpotDTO)
        {
            var parkingSpot = new ParkingSpot
            {
                Location = parkingSpotDTO.Location,
                IsOccupied = parkingSpotDTO.IsOccupied,
                Type = parkingSpotDTO.Type,
                BuildingID = parkingSpotDTO.BuildingID
            };

            _context.ParkingSpots.Add(parkingSpot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParkingSpot", new { id = parkingSpot.ParkingSpotID }, parkingSpot);
        }

        // DELETE: api/ParkingSpots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParkingSpot(int id)
        {
            var parkingSpot = await _context.ParkingSpots.FindAsync(id);
            if (parkingSpot == null)
            {
                return NotFound();
            }

            _context.ParkingSpots.Remove(parkingSpot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParkingSpotExists(int id)
        {
            return _context.ParkingSpots.Any(e => e.ParkingSpotID == id);
        }
    }

}
