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
    public class TypePlanningNewController : ControllerBase
    {
        private readonly AlchiDbContext _context;

        public TypePlanningNewController(AlchiDbContext context)
        {
            _context = context;
        }

        // GET: api/TypePlanningNew
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypePlanningNew>>> GetTypePlanningNew()
        {
            return await _context.TypePlanningNew.ToListAsync();
        }

        // GET: api/TypePlanningNew/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypePlanningNew>> GetTypePlanningNew(Guid id)
        {
            var typePlanningNew = await _context.TypePlanningNew.FindAsync(id);

            if (typePlanningNew == null)
            {
                return NotFound();
            }

            return typePlanningNew;
        }

        // PUT: api/TypePlanningNew/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypePlanningNew(Guid id, TypePlanningNew typePlanningNew)
        {
            if (id != typePlanningNew.Id)
            {
                return BadRequest();
            }

            _context.Entry(typePlanningNew).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypePlanningNewExists(id))
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

        // POST: api/TypePlanningNew
        [HttpPost]
        public async Task<ActionResult<TypePlanningNew>> PostTypePlanningNew(TypePlanningNew typePlanningNew)
        {
            _context.TypePlanningNew.Add(typePlanningNew);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypePlanningNew", new { id = typePlanningNew.Id }, typePlanningNew);
        }

        // DELETE: api/TypePlanningNew/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypePlanningNew>> DeleteTypePlanningNew(Guid id)
        {
            var typePlanningNew = await _context.TypePlanningNew.FindAsync(id);
            if (typePlanningNew == null)
            {
                return NotFound();
            }

            _context.TypePlanningNew.Remove(typePlanningNew);
            await _context.SaveChangesAsync();

            return typePlanningNew;
        }

        private bool TypePlanningNewExists(Guid id)
        {
            return _context.TypePlanningNew.Any(e => e.Id == id);
        }
    }
}
