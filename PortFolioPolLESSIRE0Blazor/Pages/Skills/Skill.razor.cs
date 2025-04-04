using PortFolioPolLESSIRE0Blazor.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;
using PortFolioPolLESSIRE0Blazor.Services;

namespace PortFolioPolLESSIRE0Blazor.Pages
{
    public partial class Skill : ComponentBase
    {
#nullable disable
        [Inject]
        public HttpClient Client { get; set; }  // Injection du HttpClient
        [Inject] public SkillService SkillService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; } // Utile si besoin de naviguer

        public List<SkillModel> Skills { get; set; } = new();
        public int SelectedId { get; set; }
        public HubConnection hubConnection { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Skills = await SkillService.GetSkillsAsync();

            hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri("https://localhost:7109/hubs/skillHub")) // Correction de l'URL du Hub
                .Build();

            hubConnection.On("notifynewskill", async () =>
            {
                Skills = await SkillService.GetSkillsAsync();
                StateHasChanged();
            });

            await hubConnection.StartAsync();
        }

        private void ClickInfo(int id) => SelectedId = id;
        
    }
}
