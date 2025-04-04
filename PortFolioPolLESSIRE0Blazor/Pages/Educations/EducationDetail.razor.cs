using PortFolioPolLESSIRE0Blazor.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace PortFolioPolLESSIRE0Blazor.Pages
{
    public partial class EducationDetail : ComponentBase
    {
    #nullable disable
        [Inject]
        public HttpClient? Client { get; set; }
        public EducationModel? CurrentEducation { get; set; }

        [Parameter]
        public int Id { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            await GetEducations();
        }
        private async Task GetEducations()
        {
            using (HttpResponseMessage message = await Client.GetAsync($"api/education/{Id}"))
            {
                if (Id <= 0) return;
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    CurrentEducation = JsonConvert.DeserializeObject<EducationModel>(json);
                }
            }
        }
    }
}
