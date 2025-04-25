using PortFolioPolLESSIRE0Blazor.Models;
using System.Net.Http.Json;

namespace PortFolioPolLESSIRE0Blazor.Services
{
    public class SkillService
    {
    #nullable disable
        private readonly HttpClient _httpClient;

        public SkillService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SkillModel>> GetSkillsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<SkillModel>>("api/skills");
        }
        public async Task<SkillModel> GetSkillByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<SkillModel>($"api/skills/{id}");
        }
    }

}















































//Copyrite https://github.com/POLLESSI

