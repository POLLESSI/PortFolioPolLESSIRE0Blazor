using PortFolioPolLESSIRE0Blazor.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace PortFolioPolLESSIRE0Blazor.Pages.Educations
{
    public partial class EducationDetail
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
            using (HttpResponseMessage message = await Client.GetAsync($"api/educations/{Id}"))
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
































//Copyrite https://github.com/POLLESSI