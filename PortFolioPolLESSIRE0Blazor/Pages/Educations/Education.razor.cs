using PortFolioPolLESSIRE0Blazor.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;
using PortFolioPolLESSIRE0Blazor.Services;

namespace PortFolioPolLESSIRE0Blazor.Pages.Educations
{
    public partial class Education
    {
#nullable disable
        [Inject] public EducationService EducationService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; } // Utile si besoin de naviguer

        public List<EducationModel> Educations { get; set; } = new();
        public int SelectedId { get; set; }
        public HubConnection hubConnection { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Educations = await EducationService.GetEducationsAsync();

            hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri("https://localhost:7109/hubs/educationHub")) // Correction de l'URL du Hub
                .Build();

            hubConnection.On("notifyneweducation", async () =>
            {
                Educations = await EducationService.GetEducationsAsync();
                StateHasChanged();
            });

            await hubConnection.StartAsync();
        }

        private void ClickInfo(int id) => SelectedId = id;
        
    }
}
