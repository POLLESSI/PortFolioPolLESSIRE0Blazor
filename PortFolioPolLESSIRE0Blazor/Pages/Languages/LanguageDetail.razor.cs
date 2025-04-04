using PortFolioPolLESSIRE0Blazor.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace PortFolioPolLESSIRE0Blazor.Pages
{
    public partial class LanguageDetail : ComponentBase
    {
    #nullable disable
        [Inject]
        public HttpClient? Client { get; set; }
        public LanguageModel? CurrentLanguage { get; set; }

        [Parameter]
        public int Id { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            await GetLanguages();
        }
        private async Task GetLanguages()
        {
            if (Id <= 0) return;
            using (HttpResponseMessage message = await Client.GetAsync($"api/language/{Id}"))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    CurrentLanguage = JsonConvert.DeserializeObject<LanguageModel>(json);
                }
            }
        }
    }
}
