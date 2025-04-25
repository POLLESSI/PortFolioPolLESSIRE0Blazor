using PortFolioPolLESSIRE0Blazor.Models;
using System.Net.Http.Json;

namespace PortFolioPolLESSIRE0Blazor.Services
{
    public class LanguageService
    {
    #nullable disable
        private readonly HttpClient _httpClient;

        public LanguageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<LanguageModel>> GetLanguagesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<LanguageModel>>("api/languages");
        }
        public async Task<LanguageModel> GetLanguageByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<LanguageModel>($"api/lSSanguages/{id}");
        }
    }
}








































//Copyrite https://github.com/POLLESSI


