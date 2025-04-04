using PortFolioPolLESSIRE0Blazor.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;
using PortFolioPolLESSIRE0Blazor.Services;

namespace PortFolioPolLESSIRE0Blazor.Pages
{
    public partial class Language : ComponentBase
    {
#nullable disable
        [Inject]
        public HttpClient Client { get; set; }  // Injection du HttpClient
        [Inject] public LanguageService LanguageService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; } // Utile si besoin de naviguer

        public List<LanguageModel> Languages { get; set; } = new();
        public int SelectedId { get; set; }
        public HubConnection hubConnection { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Languages = await LanguageService.GetLanguagesAsync();

            hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri("https://localhost:7109/hubs/languageHub")) // Correction de l'URL du Hub
                .Build();

            hubConnection.On("notifynewlanguage", async () =>
            {
                Languages = await LanguageService.GetLanguagesAsync();
                StateHasChanged();
            });

            await hubConnection.StartAsync();
        }

        private void ClickInfo(int id) => SelectedId = id;
        
    }
}
