using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pointeuse.Data;
using Pointeuse.Data.Models;

namespace Pointeuse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GroupesController(ApplicationDbContext context) => _context = context;

        // GET /api/groupes
        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _context.Groupes.AsNoTracking().ToListAsync());

        // GET /api/groupes/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Groupe>> GetById(int id)
        {
            var g = await _context.Groupes.FindAsync(id);
            if (g == null) return NotFound();
            return Ok(g);
        }

        // POST /api/groupes
        [HttpPost]
        public async Task<ActionResult<Groupe>> Create([FromBody] Groupe g)
        {
            if (string.IsNullOrWhiteSpace(g.Type))
                return BadRequest("Type requis (ex: FE / FA).");

            _context.Groupes.Add(g);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = g.Id }, g);
        }

        // PUT /api/groupes/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Groupe g)
        {
            if (id != g.Id)
                return BadRequest("Id incohérent.");

            if (!await _context.Groupes.AnyAsync(x => x.Id == id))
                return NotFound();

            _context.Entry(g).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /api/groupes/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var g = await _context.Groupes.FindAsync(id);
            if (g == null) return NotFound();

            _context.Groupes.Remove(g);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
