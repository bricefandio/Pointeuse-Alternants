using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pointeuse.Data;
using Pointeuse.Data.Models;


namespace Pointeuse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PromotionsController(ApplicationDbContext context) => _context = context;

        // GET /api/promotions
        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _context.Promotions.AsNoTracking().ToListAsync());

        // GET /api/promotions/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Promotion>> GetById(int id)
        {
            var p = await _context.Promotions.FindAsync(id);
            if (p == null) return NotFound();
            return Ok(p);
        }

        // POST /api/promotions
        [HttpPost]
        public async Task<ActionResult<Promotion>> Create([FromBody] Promotion p)
        {
            if (string.IsNullOrWhiteSpace(p.Annee))
                return BadRequest("Année requise (ex: 2024).");

            _context.Promotions.Add(p);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = p.Id }, p);
        }

        // PUT /api/promotions/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Promotion p)
        {
            if (id != p.Id)
                return BadRequest("Id incohérent.");

            if (!await _context.Promotions.AnyAsync(x => x.Id == id))
                return NotFound();

            _context.Entry(p).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /api/promotions/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var p = await _context.Promotions.FindAsync(id);
            if (p == null) return NotFound();

            _context.Promotions.Remove(p);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }


}
