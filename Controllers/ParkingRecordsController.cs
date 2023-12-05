using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projecto_bases_de_datos_api.Models.DTO;
using projecto_bases_de_datos_api.Models;

namespace projecto_bases_de_datos_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingRecordsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParkingRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ParkingRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingRecord>>> GetParkingRecords()
        {
            return await _context.ParkingRecords.ToListAsync();
        }

        // GET: api/ParkingRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingRecord>> GetParkingRecord(int id)
        {
            var parkingRecord = await _context.ParkingRecords.FindAsync(id);

            if (parkingRecord == null)
            {
                return NotFound();
            }

            return parkingRecord;
        }

        // POST: api/ParkingRecords
        [HttpPost]
        public async Task<ActionResult<ParkingRecord>> PostParkingRecord(CreateParkingRecordDTO parkingRecordDTO)
        {
            var parkingRecord = new ParkingRecord
            {
                ParkingSpotID = parkingRecordDTO.ParkingSpotID,
                UserID = parkingRecordDTO.UserID,
                VehicleID = parkingRecordDTO.VehicleID,
                EntryTime = parkingRecordDTO.EntryTime
            };

            _context.ParkingRecords.Add(parkingRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParkingRecord", new { id = parkingRecord.ParkingRecordID }, parkingRecord);
        }

        // PUT: api/ParkingRecords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParkingRecord(int id, UpdateParkingRecordDTO parkingRecordDTO)
        {

            var parkingRecord = await _context.ParkingRecords.FindAsync(id);
            if (parkingRecord == null)
            {
                return NotFound();
            }

            parkingRecord.ExitTime = parkingRecordDTO.ExitTime;

            _context.Entry(parkingRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingRecordExists(id))
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

        // DELETE: api/ParkingRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParkingRecord(int id)
        {
            var parkingRecord = await _context.ParkingRecords.FindAsync(id);
            if (parkingRecord == null)
            {
                return NotFound();
            }

            _context.ParkingRecords.Remove(parkingRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParkingRecordExists(int id)
        {
            return _context.ParkingRecords.Any(e => e.ParkingRecordID == id);
        }
    }

}
