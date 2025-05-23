﻿using System.Net.Http.Json;
using PortFolioPolLESSIRE0Blazor.Models;

namespace PortFolioPolLESSIRE0Blazor.Services
{
    public class InterestService
    {
    #nullable disable
        private readonly HttpClient _httpClient;

        public InterestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<InterestModel>> GetInterestsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<InterestModel>>("api/interests");
        }
        public async Task<InterestModel> GetInterestByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<InterestModel>($"api/interests/{id}");
        }
    }
}















































//Copyrite https://github.com/POLLESSI


