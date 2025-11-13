using System.Net.Http.Json;
using Pointeuse.WebApp.Models;

namespace Pointeuse.WebApp.Services
{
    public class ApiClient
    {
        private readonly HttpClient _http;

        public ApiClient(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("API");
        }

        public async Task<List<EtudiantDto>> GetEtudiantsAsync() =>
            await _http.GetFromJsonAsync<List<EtudiantDto>>("/api/etudiants");

        public async Task<List<GroupeDto>> GetGroupesAsync() =>
            await _http.GetFromJsonAsync<List<GroupeDto>>("/api/groupes");

        public async Task<List<PromotionDto>> GetPromotionsAsync() =>
            await _http.GetFromJsonAsync<List<PromotionDto>>("/api/promotions");

        public async Task<List<PointageDto>> GetPointagesAsync()
        {
            var list = await _http.GetFromJsonAsync<List<PointageDto>>("/api/pointages");
            return list ?? new List<PointageDto>();
        }
        public async Task<bool> LoginAsync(string username, string password)
        {
            var response = await _http.PostAsJsonAsync("/api/auth/login", new { Username = username, Password = password });
            return response.IsSuccessStatusCode;
        }

    }
}
