using PortFolioPolLESSIRE0Blazor.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;
using PortFolioPolLESSIRE0Blazor.Services;

namespace PortFolioPolLESSIRE0Blazor.Pages.Projects
{
    public partial class Project
    {
#nullable disable
        [Inject]
        public HttpClient Client { get; set; }  // Injection du HttpClient
        [Inject] public ProjectService ProjectService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; } // Utile si besoin de naviguer

        public List<ProjectModel> Projects { get; set; } = new();
        public int SelectedId { get; set; }
        public HubConnection hubConnection { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Projects = await ProjectService.GetProjectsAsync();

            hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri("https://localhost:7109/hubs/projectHub")) // Correction de l'URL du Hub
                .Build();

            hubConnection.On("notifynewproject", async () =>
            {
                Projects = await ProjectService.GetProjectsAsync();
                StateHasChanged();
            });

            await hubConnection.StartAsync();
        }

        private void ClickInfo(int id) => SelectedId = id;

    }

}




































//Copyrite https://github.com/POLLESSI
