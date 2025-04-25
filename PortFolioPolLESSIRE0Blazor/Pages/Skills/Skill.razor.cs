using PortFolioPolLESSIRE0Blazor.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;
using PortFolioPolLESSIRE0Blazor.Services;

namespace PortFolioPolLESSIRE0Blazor.Pages.Skills
{
    public partial class Skill
    {
#nullable disable
        [Inject]
        public HttpClient Client { get; set; }  
        [Inject] public SkillService SkillService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; } 

        public List<SkillModel> Skills { get; set; } = new();
        public int SelectedId { get; set; }
        public HubConnection hubConnection { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Skills = await SkillService.GetSkillsAsync();

            hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri("https://localhost:7109/hubs/skillHub")) 
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






































//Copyrite https://github.com/POLLESSI
