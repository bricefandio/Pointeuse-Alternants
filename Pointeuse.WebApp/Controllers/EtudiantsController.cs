using Microsoft.AspNetCore.Mvc;
using Pointeuse.WebApp.Services;

namespace Pointeuse.WebApp.Controllers
{
    public class EtudiantsController : Controller
    {
        private readonly ApiClient _api;

        public EtudiantsController(ApiClient api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            var etudiants = await _api.GetEtudiantsAsync();
            return View(etudiants);
        }
    }
}
