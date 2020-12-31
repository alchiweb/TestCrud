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
    public class ChauffeurNewController : ControllerBase
    {
        private readonly AlchiDbContext _context;

        public ChauffeurNewController(AlchiDbContext context)
        {
            _context = context;
        }

        // GET: api/ChauffeurNew
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChauffeurNew>>> GetChauffeurNew()
        {
            return await _context.ChauffeurNew.ToListAsync();
        }

        // GET: api/ChauffeurNew/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChauffeurNew>> GetChauffeurNew(Guid id)
        {
            var chauffeurNew = await _context.ChauffeurNew.FindAsync(id);

            if (chauffeurNew == null)
            {
                return NotFound();
            }

            return chauffeurNew;
        }

        // PUT: api/ChauffeurNew/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChauffeurNew(Guid id, ChauffeurNew chauffeurNew)
        {
            if (id != chauffeurNew.Id)
            {
                return BadRequest();
            }

            _context.Entry(chauffeurNew).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChauffeurNewExists(id))
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

        // POST: api/ChauffeurNew
        [HttpPost]
        public async Task<ActionResult<ChauffeurNew>> PostChauffeurNew(ChauffeurNew chauffeurNew)
        {
            _context.ChauffeurNew.Add(chauffeurNew);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChauffeurNew", new { id = chauffeurNew.Id }, chauffeurNew);
        }

        // DELETE: api/ChauffeurNew/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChauffeurNew>> DeleteChauffeurNew(Guid id)
        {
            var chauffeurNew = await _context.ChauffeurNew.FindAsync(id);
            if (chauffeurNew == null)
            {
                return NotFound();
            }

            _context.ChauffeurNew.Remove(chauffeurNew);
            await _context.SaveChangesAsync();

            return chauffeurNew;
        }

        private bool ChauffeurNewExists(Guid id)
        {
            return _context.ChauffeurNew.Any(e => e.Id == id);
        }
    }
}
