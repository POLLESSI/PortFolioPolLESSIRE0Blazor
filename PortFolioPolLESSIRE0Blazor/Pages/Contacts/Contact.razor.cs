using PortFolioPolLESSIRE0Blazor.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;
using PortFolioPolLESSIRE0Blazor.Services;

namespace PortFolioPolLESSIRE0Blazor.Pages.Contacts
{
    public partial class Contact
    {
    #nullable disable
        [Inject]
        public HttpClient Client { get; set; }  // Injection HttpClient
        [Inject] public ContactService ContactService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; } 

        public List<ContactModel> Contacts { get; set; } = new();
        public int SelectedId { get; set; }
        public HubConnection hubConnection { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Contacts = await ContactService.GetContactsAsync();

            hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri("https://localhost:7109/hubs/contactHub")) 
                .Build();

            hubConnection.On("notifynewcontact", async () =>
            {
                Contacts = await ContactService.GetContactsAsync();
                StateHasChanged();
            });

            await hubConnection.StartAsync();
        }

        private void ClickInfo(int id) => SelectedId = id;
        
    }
}
































//Copyrite https://github.com/POLLESSI