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
    public class TypeVehiculeNewController : ControllerBase
    {
        private readonly AlchiDbContext _context;

        public TypeVehiculeNewController(AlchiDbContext context)
        {
            _context = context;
        }

        // GET: api/TypeVehiculeNew
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeVehiculeNew>>> GetTypeVehiculeNew()
        {
            return await _context.TypeVehiculeNew.ToListAsync();
        }

        // GET: api/TypeVehiculeNew/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeVehiculeNew>> GetTypeVehiculeNew(Guid id)
        {
            var typeVehiculeNew = await _context.TypeVehiculeNew.FindAsync(id);

            if (typeVehiculeNew == null)
            {
                return NotFound();
            }

            return typeVehiculeNew;
        }

        // PUT: api/TypeVehiculeNew/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeVehiculeNew(Guid id, TypeVehiculeNew typeVehiculeNew)
        {
            if (id != typeVehiculeNew.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeVehiculeNew).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeVehiculeNewExists(id))
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

        // POST: api/TypeVehiculeNew
        [HttpPost]
        public async Task<ActionResult<TypeVehiculeNew>> PostTypeVehiculeNew(TypeVehiculeNew typeVehiculeNew)
        {
            _context.TypeVehiculeNew.Add(typeVehiculeNew);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeVehiculeNew", new { id = typeVehiculeNew.Id }, typeVehiculeNew);
        }

        // DELETE: api/TypeVehiculeNew/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeVehiculeNew>> DeleteTypeVehiculeNew(Guid id)
        {
            var typeVehiculeNew = await _context.TypeVehiculeNew.FindAsync(id);
            if (typeVehiculeNew == null)
            {
                return NotFound();
            }

            _context.TypeVehiculeNew.Remove(typeVehiculeNew);
            await _context.SaveChangesAsync();

            return typeVehiculeNew;
        }

        private bool TypeVehiculeNewExists(Guid id)
        {
            return _context.TypeVehiculeNew.Any(e => e.Id == id);
        }
    }
}
