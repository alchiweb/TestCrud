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
    public class CategorieVehiculeNewController : ControllerBase
    {
        private readonly AlchiDbContext _context;

        public CategorieVehiculeNewController(AlchiDbContext context)
        {
            _context = context;
        }

        // GET: api/CategorieVehiculeNew
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorieVehiculeNew>>> GetCategorieVehiculeNew()
        {
            return await _context.CategorieVehiculeNew.ToListAsync();
        }

        // GET: api/CategorieVehiculeNew/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategorieVehiculeNew>> GetCategorieVehiculeNew(Guid id)
        {
            var categorieVehiculeNew = await _context.CategorieVehiculeNew.FindAsync(id);

            if (categorieVehiculeNew == null)
            {
                return NotFound();
            }

            return categorieVehiculeNew;
        }

        // PUT: api/CategorieVehiculeNew/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorieVehiculeNew(Guid id, CategorieVehiculeNew categorieVehiculeNew)
        {
            if (id != categorieVehiculeNew.Id)
            {
                return BadRequest();
            }

            _context.Entry(categorieVehiculeNew).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieVehiculeNewExists(id))
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

        // POST: api/CategorieVehiculeNew
        [HttpPost]
        public async Task<ActionResult<CategorieVehiculeNew>> PostCategorieVehiculeNew(CategorieVehiculeNew categorieVehiculeNew)
        {
            _context.CategorieVehiculeNew.Add(categorieVehiculeNew);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorieVehiculeNew", new { id = categorieVehiculeNew.Id }, categorieVehiculeNew);
        }

        // DELETE: api/CategorieVehiculeNew/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategorieVehiculeNew>> DeleteCategorieVehiculeNew(Guid id)
        {
            var categorieVehiculeNew = await _context.CategorieVehiculeNew.FindAsync(id);
            if (categorieVehiculeNew == null)
            {
                return NotFound();
            }

            _context.CategorieVehiculeNew.Remove(categorieVehiculeNew);
            await _context.SaveChangesAsync();

            return categorieVehiculeNew;
        }

        private bool CategorieVehiculeNewExists(Guid id)
        {
            return _context.CategorieVehiculeNew.Any(e => e.Id == id);
        }
    }
}
