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
    public class AdresseNewController : ControllerBase
    {
        private readonly AlchiDbContext _context;

        public AdresseNewController(AlchiDbContext context)
        {
            _context = context;
        }

        // GET: api/AdresseNew
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdresseNew>>> GetAdresseNew()
        {
            return await _context.AdresseNew.ToListAsync();
        }

        // GET: api/AdresseNew/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdresseNew>> GetAdresseNew(Guid id)
        {
            var adresseNew = await _context.AdresseNew.FindAsync(id);

            if (adresseNew == null)
            {
                return NotFound();
            }

            return adresseNew;
        }

        // PUT: api/AdresseNew/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdresseNew(Guid id, AdresseNew adresseNew)
        {
            if (id != adresseNew.Id)
            {
                return BadRequest();
            }

            _context.Entry(adresseNew).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdresseNewExists(id))
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

        // POST: api/AdresseNew
        [HttpPost]
        public async Task<ActionResult<AdresseNew>> PostAdresseNew(AdresseNew adresseNew)
        {
            _context.AdresseNew.Add(adresseNew);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdresseNew", new { id = adresseNew.Id }, adresseNew);
        }

        // DELETE: api/AdresseNew/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AdresseNew>> DeleteAdresseNew(Guid id)
        {
            var adresseNew = await _context.AdresseNew.FindAsync(id);
            if (adresseNew == null)
            {
                return NotFound();
            }

            _context.AdresseNew.Remove(adresseNew);
            await _context.SaveChangesAsync();

            return adresseNew;
        }

        private bool AdresseNewExists(Guid id)
        {
            return _context.AdresseNew.Any(e => e.Id == id);
        }
    }
}
