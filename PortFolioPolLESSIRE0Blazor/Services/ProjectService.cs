using PortFolioPolLESSIRE0Blazor.Models;
using System.Net.Http.Json;

namespace PortFolioPolLESSIRE0Blazor.Services
{
    public class ProjectService
    {
    #nullable disable
        private readonly HttpClient _httpClient;

        public ProjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProjectModel>> GetProjectsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ProjectModel>>("api/projects");
        }
    }
}


