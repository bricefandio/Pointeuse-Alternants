using System.Net.Http;
using System.Net.Http.Json;
using Pointeuse.Maui.Models;

namespace Pointeuse.Maui.Services
{
    public class ApiClient
    {
        private readonly HttpClient _http;

        public ApiClient(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("API");
        }

        // 🔐 LOGIN
        public async Task<bool> LoginAsync(string username, string password)
        {
            var response = await _http.PostAsJsonAsync("/api/auth/login", new
            {
                Username = username,
                Password = password
            });

            return response.IsSuccessStatusCode;
        }

        // ➕ CRÉER ÉTUDIANT
        public async Task<EtudiantDto?> CreateEtudiantAsync(EtudiantDto etudiant)
        {
            var response = await _http.PostAsJsonAsync("/api/etudiants", etudiant);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<EtudiantDto>();
        }

        // 📦 RÉCUPÉRER ÉTUDIANTS
        public async Task<List<EtudiantDto>> GetEtudiantsAsync()
        {
            return await _http.GetFromJsonAsync<List<EtudiantDto>>("/api/etudiants")
                   ?? new List<EtudiantDto>();
        }

        // 📌 GROUPES
        public async Task<List<GroupeDto>> GetGroupesAsync()
        {
            return await _http.GetFromJsonAsync<List<GroupeDto>>("/api/groupes")
                   ?? new List<GroupeDto>();
        }

        // 🎓 PROMOTIONS
        public async Task<List<PromotionDto>> GetPromotionsAsync()
        {
            return await _http.GetFromJsonAsync<List<PromotionDto>>("/api/promotions")
                   ?? new List<PromotionDto>();
        }
    }
}
