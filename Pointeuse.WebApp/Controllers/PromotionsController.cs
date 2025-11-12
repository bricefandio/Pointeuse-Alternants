using Microsoft.AspNetCore.Mvc;
using Pointeuse.WebApp.Services;

namespace Pointeuse.WebApp.Controllers
{
    public class PromotionsController : Controller
    {
        private readonly ApiClient _api;
        public PromotionsController(ApiClient api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            var promos = await _api.GetPromotionsAsync();
            return View(promos);
        }
    }
}
