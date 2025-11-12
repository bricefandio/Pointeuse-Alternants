using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Pointeuse.DesktopGestion.Models;
using System;
using System.Collections.Generic;


namespace Pointeuse.DesktopGestion.Services
{
    public class ApiClient
    {
        private readonly HttpClient _http;

        public ApiClient(string baseUrl)
        {
            _http = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        // =======================
        // ÉTUDIANTS
        // =======================
        public async Task<List<EtudiantDto>> GetEtudiantsAsync() =>
            await _http.GetFromJsonAsync<List<EtudiantDto>>("/api/etudiants");

        public async Task<EtudiantDto> CreateEtudiantAsync(EtudiantDto e)
        {
            var response = await _http.PostAsJsonAsync("/api/etudiants", e);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<EtudiantDto>();
        }

        public async Task UpdateEtudiantAsync(int id, EtudiantDto e)
        {
            var response = await _http.PutAsJsonAsync($"/api/etudiants/{id}", e);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteEtudiantAsync(int id)
        {
            var response = await _http.DeleteAsync($"/api/etudiants/{id}");
            response.EnsureSuccessStatusCode();
        }

        // =======================
        // GROUPES
        // =======================
        public async Task<List<GroupeDto>> GetGroupesAsync() =>
            await _http.GetFromJsonAsync<List<GroupeDto>>("/api/groupes");

        public async Task CreateGroupeAsync(GroupeDto g)
        {
            var response = await _http.PostAsJsonAsync("/api/groupes", g);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateGroupeAsync(int id, GroupeDto g)
        {
            var response = await _http.PutAsJsonAsync($"/api/groupes/{id}", g);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteGroupeAsync(int id)
        {
            var response = await _http.DeleteAsync($"/api/groupes/{id}");
            response.EnsureSuccessStatusCode();
        }

        // =======================
        // PROMOTIONS
        // =======================
        public async Task<List<PromotionDto>> GetPromotionsAsync() =>
            await _http.GetFromJsonAsync<List<PromotionDto>>("/api/promotions");

        public async Task CreatePromotionAsync(PromotionDto p)
        {
            var response = await _http.PostAsJsonAsync("/api/promotions", p);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdatePromotionAsync(int id, PromotionDto p)
        {
            var response = await _http.PutAsJsonAsync($"/api/promotions/{id}", p);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeletePromotionAsync(int id)
        {
            var response = await _http.DeleteAsync($"/api/promotions/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var response = await _http.PostAsJsonAsync("/api/auth/login", new
            {
                Username = username,
                Password = password
            });

            return response.IsSuccessStatusCode;
        }
    }
}
