using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCrud.Data;
using TestCrud.Models;

namespace TestCrud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculeNewController : ControllerBase
    {
        private readonly AlchiDbContext _context;

        public VehiculeNewController(AlchiDbContext context)
        {
            _context = context;
        }

        // GET: api/VehiculeNew
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehiculeNew>>> GetVehiculeNew()
        {
            return await _context.VehiculeNew.ToListAsync();
        }

        // GET: api/VehiculeNew/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehiculeNew>> GetVehiculeNew(Guid id)
        {
            var vehiculeNew = await _context.VehiculeNew.FindAsync(id);

            if (vehiculeNew == null)
            {
                return NotFound();
            }

            return vehiculeNew;
        }

        // PUT: api/VehiculeNew/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculeNew(Guid id, VehiculeNew vehiculeNew)
        {
            if (id != vehiculeNew.Id)
            {
                return BadRequest();
            }

            _context.Entry(vehiculeNew).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculeNewExists(id))
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

        // POST: api/VehiculeNew
        [HttpPost]
        public async Task<ActionResult<VehiculeNew>> PostVehiculeNew(VehiculeNew vehiculeNew)
        {
            _context.VehiculeNew.Add(vehiculeNew);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehiculeNew", new { id = vehiculeNew.Id }, vehiculeNew);
        }

        // DELETE: api/VehiculeNew/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehiculeNew>> DeleteVehiculeNew(Guid id)
        {
            var vehiculeNew = await _context.VehiculeNew.FindAsync(id);
            if (vehiculeNew == null)
            {
                return NotFound();
            }

            _context.VehiculeNew.Remove(vehiculeNew);
            await _context.SaveChangesAsync();

            return vehiculeNew;
        }

        private bool VehiculeNewExists(Guid id)
        {
            return _context.VehiculeNew.Any(e => e.Id == id);
        }
    }
}
