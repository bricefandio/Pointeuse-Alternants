using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pointeuse.Data;
using Pointeuse.Data.Models;

namespace Pointeuse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EtudiantsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EtudiantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _context.Etudiants
                .Include(e => e.Groupe)
                .Include(e => e.Promotion)
                .ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var e = await _context.Etudiants
                .Include(e => e.Groupe)
                .Include(e => e.Promotion)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (e == null) return NotFound();
            return Ok(e);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Etudiant e)
        {
            _context.Etudiants.Add(e);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = e.Id }, e);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Etudiant e)
        {
            if (id != e.Id) return BadRequest();
            _context.Entry(e).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var e = await _context.Etudiants.FindAsync(id);
            if (e == null) return NotFound();
            _context.Etudiants.Remove(e);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
