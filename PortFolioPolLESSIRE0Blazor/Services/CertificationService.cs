using System.Net.Http.Json;
using PortFolioPolLESSIRE0Blazor.Models;

namespace PortFolioPolLESSIRE0Blazor.Services
{
    public class CertificationService
    {
#nullable disable
        private readonly HttpClient _httpClient;

        public CertificationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CertificationModel>> GetCertificationsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CertificationModel>>("api/certifications");
        }
    }
}



