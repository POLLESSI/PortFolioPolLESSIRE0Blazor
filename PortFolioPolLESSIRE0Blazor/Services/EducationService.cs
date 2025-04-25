using System.Net.Http.Json;
using PortFolioPolLESSIRE0Blazor.Models;

namespace PortFolioPolLESSIRE0Blazor.Services
{
    public class EducationService
    {
    #nullable disable
        private readonly HttpClient _httpClient;

        public EducationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EducationModel>> GetEducationsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<EducationModel>>("api/educations");
        }
        public async Task<EducationModel> GetEducationByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<EducationModel>($"api/educations/{id}");
        }
    }
}





































//Copyrite https://github.com/POLLESSI


