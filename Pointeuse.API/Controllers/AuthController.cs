using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pointeuse.Data;
using Pointeuse.Data.Models;

namespace Pointeuse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST /api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Utilisateur login)
        {
            if (login == null ||
                string.IsNullOrWhiteSpace(login.Username) ||
                string.IsNullOrWhiteSpace(login.Password))
            {
                return BadRequest(new { message = "Champs manquants." });
            }

            var user = await _context.Utilisateurs
                .FirstOrDefaultAsync(u => u.Username == login.Username &&
                                          u.Password == login.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Identifiants invalides." });
            }

            // Réponse UNIQUE pour Web, MAUI, Desktop
            return Ok(new
            {
                message = "Connexion réussie",
                username = user.Username
            });
        }
    }
}
