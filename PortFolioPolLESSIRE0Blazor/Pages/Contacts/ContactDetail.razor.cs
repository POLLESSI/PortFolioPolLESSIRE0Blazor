using PortFolioPolLESSIRE0Blazor.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace PortFolioPolLESSIRE0Blazor.Pages.Contacts
{
    public partial class ContactDetail 
    {
    #nullable disable
        [Inject]
        public HttpClient? Client { get; set; }
        public ContactModel? CurrentContact { get; set; }

        [Parameter]
        public int Id { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            await GetContacts();
        }
        private async Task GetContacts()
        {
            if (Id <= 0) return;
            using (HttpResponseMessage message = await Client.GetAsync($"api/contacts/{Id}"))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    CurrentContact = JsonConvert.DeserializeObject<ContactModel>(json);
                }
            }
        }
    }
}




























//Copyrite https://github.com/POLLESSI