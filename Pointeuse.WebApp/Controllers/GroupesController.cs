using Microsoft.AspNetCore.Mvc;
using Pointeuse.WebApp.Services;

namespace Pointeuse.WebApp.Controllers
{
    public class GroupesController : Controller
    {
        private readonly ApiClient _api;
        public GroupesController(ApiClient api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            var groupes = await _api.GetGroupesAsync();
            return View(groupes);
        }
    }
}
