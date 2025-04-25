using PortFolioPolLESSIRE0Blazor.Models;
using PortFolioPolLESSIRE0Blazor.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;


namespace PortFolioPolLESSIRE0Blazor.Pages.Experiences
{
    public partial class Experience
    {
#nullable disable
        [Inject]
        public HttpClient Client { get; set; }  
        [Inject] public ExperienceService ExperienceService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; } 

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
            });

            await hubConnection.StartAsync();
        }

        private void ClickInfo(int id)
        {
            SelectedId = id;
        }
    }
}

































//Copyrite https://github.com/POLLESSI
