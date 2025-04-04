using PortFolioPolLESSIRE0Blazor.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;
using PortFolioPolLESSIRE0Blazor.Services;

namespace PortFolioPolLESSIRE0Blazor.Pages
{
    public partial class Experience : ComponentBase
    {
#nullable disable
        [Inject]
        public HttpClient Client { get; set; }  // Injection du HttpClient
        [Inject] public ExperienceService ExperienceService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; } // Utile si besoin de naviguer

        public List<ExperienceModel> Experiences { get; set; } = new();
        public int SelectedId { get; set; }
        public HubConnection hubConnection { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Experiences = await ExperienceService.GetExperiencesAsync();

            hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri("https://localhost:7109/hubs/experienceHub")) // Correction de l'URL du Hub
                .Build();

            hubConnection.On("notifynewexperience", async () =>
            {
                Experiences = await ExperienceService.GetExperiencesAsync();
                StateHasChanged();
            });

            await hubConnection.StartAsync();
        }

        private void ClickInfo(int id) => SelectedId = id;
        
    }
}
