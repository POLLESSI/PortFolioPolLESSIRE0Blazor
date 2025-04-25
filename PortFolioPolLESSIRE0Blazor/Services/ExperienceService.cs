using System.Net.Http.Json;
using PortFolioPolLESSIRE0Blazor.Models;

namespace PortFolioPolLESSIRE0Blazor.Services
{
    public class ExperienceService
    {
    #nullable disable
        private readonly HttpClient _httpClient;

        public ExperienceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ExperienceModel>> GetExperiencesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ExperienceModel>>("api/experiences");
        }
        public async Task<ExperienceModel> GetExperienceByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ExperienceModel>($"api/experiences/{id}");
        }
    }
}





































//Copyrite https://github.com/POLLESSI

