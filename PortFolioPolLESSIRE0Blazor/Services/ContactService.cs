using System.Net.Http.Json;
using PortFolioPolLESSIRE0Blazor.Models;

namespace PortFolioPolLESSIRE0Blazor.Services 
{
    #nullable disable
    public class ContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ContactModel>> GetContactsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ContactModel>>("api/contacts");
        }
        public async Task<ContactModel> GetContactByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ContactModel>($"api/contacts/{id}");
        }
    }
}




































//Copyrite https://github.com/POLLESSI


