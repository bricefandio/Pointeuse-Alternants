using Microsoft.AspNetCore.Mvc;
using Pointeuse.WebApp.Services;

namespace Pointeuse.WebApp.Controllers
{
    public class PointagesController : Controller
    {
        private readonly ApiClient _api;

        public PointagesController(ApiClient api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            var pointages = await _api.GetPointagesAsync();

            // On peut trier pour que les plus récents soient en haut
            pointages = pointages.OrderByDescending(p => p.DateHeureScan).ToList();

            return View(pointages);
        }
    }
}
