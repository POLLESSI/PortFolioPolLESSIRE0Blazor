using PortFolioPolLESSIRE0Blazor.Models;
using PortFolioPolLESSIRE0Blazor.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;

namespace PortFolioPolLESSIRE0Blazor.Pages.Certifications
{
    public partial class Certification
    {
#nullable disable
        [Inject]
        public HttpClient Client { get; set; }  // Injection du HttpClient
        [Inject] public CertificationService CertificationService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; } // Utile si besoin de naviguer

        public List<CertificationModel> Certifications { get; set; } = new();
        public int SelectedId { get; set; }
        public HubConnection hubConnection { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Certifications = await CertificationService.GetCertificationsAsync();

            hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri("https://localhost:7109/hubs/certificationHub")) // Correction de l'URL du Hub
                .Build();

            hubConnection.On("notifynewcertification", async () =>
            {
                Certifications = await CertificationService.GetCertificationsAsync();
                StateHasChanged();
            });

            await hubConnection.StartAsync();
        }

        private void ClickInfo(int id) => SelectedId = id;
        
    }
}
