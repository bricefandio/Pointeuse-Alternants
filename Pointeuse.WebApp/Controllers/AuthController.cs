using Microsoft.AspNetCore.Mvc;
using Pointeuse.WebApp.Models;
using Pointeuse.WebApp.Services;

namespace Pointeuse.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApiClient _api;

        public AuthController(ApiClient api)
        {
            _api = api;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin model)
        {
            if (string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.Password))
            {
                ViewBag.Error = "Veuillez saisir vos identifiants.";
                return View(model);
            }

            bool ok = await _api.LoginAsync(model.Username, model.Password);

            if (ok)
            {
                HttpContext.Session.SetString("User", model.Username);
                return RedirectToAction("Index", "Etudiants");
            }

            ViewBag.Error = "Identifiants invalides.";
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
