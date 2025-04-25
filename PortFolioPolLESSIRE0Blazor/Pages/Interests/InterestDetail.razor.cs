using PortFolioPolLESSIRE0Blazor.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace PortFolioPolLESSIRE0Blazor.Pages.Interests
{
    public partial class InterestDetail
    {
    #nullable disable
        [Inject]
        public HttpClient? Client { get; set; }
        public InterestModel? CurrentInterest { get; set; }

        [Parameter]
        public int Id { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            await GetInterests();
        }
        private async Task GetInterests()
        {
            if (Id <= 0) return;
            using (HttpResponseMessage message = await Client.GetAsync($"interests/{Id}"))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    CurrentInterest = JsonConvert.DeserializeObject<InterestModel>(json);
                }
            }
        }
    }
}


































//Copyrite https://github.com/POLLESSI