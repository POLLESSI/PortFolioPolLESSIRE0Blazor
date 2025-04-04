using PortFolioPolLESSIRE0Blazor.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;
using PortFolioPolLESSIRE0Blazor.Services;

namespace PortFolioPolLESSIRE0Blazor.Pages.Interests
{
    public partial class Interest
    {
    #nullable disable
        [Inject]
        public HttpClient Client { get; set; }  // Injection du HttpClient
        [Inject] public InterestService InterestService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; } // Utile si besoin de naviguer

        public List<InterestModel> Interests { get; set; } = new();
        public int SelectedId { get; set; }
        public HubConnection hubConnection { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Interests = await InterestService.GetInterestsAsync();

            hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri("https://localhost:7109/hubs/interestHub")) // Correction de l'URL du Hub
                .Build();

            hubConnection.On("notifynewinterest", async () =>
            {
                Interests = await InterestService.GetInterestsAsync();
                StateHasChanged();
            });

            await hubConnection.StartAsync();
        }

        private void ClickInfo(int id) => SelectedId = id;
        
    }
}
