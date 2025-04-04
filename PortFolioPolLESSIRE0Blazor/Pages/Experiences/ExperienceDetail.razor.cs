using PortFolioPolLESSIRE0Blazor.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace PortFolioPolLESSIRE0Blazor.Pages.Experiences
{
    public partial class ExperienceDetail : ComponentBase
    {
    #nullable disable
        [Inject]
        public HttpClient? Client { get; set; }
        public ExperienceModel? CurrentExperience { get; set; }

        [Parameter]
        public int Id { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            await GetExperiences();
        }
        private async Task GetExperiences()
        {
            using (HttpResponseMessage message = await Client.GetAsync($"api/experience/{Id}"))
            {
                if (Id <= 0) return;
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    CurrentExperience = JsonConvert.DeserializeObject<ExperienceModel>(json);
                }
            }
        }
    }
}
