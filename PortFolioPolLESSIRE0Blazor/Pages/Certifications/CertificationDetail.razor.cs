using PortFolioPolLESSIRE0Blazor.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace PortFolioPolLESSIRE0Blazor.Pages.Certifications
{
    public partial class CertificationDetail
    {
    #nullable disable
        [Inject]
        public HttpClient? Client { get; set; }
        public CertificationModel? CurrentCertification { get; set; }

        [Parameter]
        public int Id { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            await GetCertifications();
        }
        private async Task GetCertifications()
        {
            if (Id <= 0) return;

            using (HttpResponseMessage message = await Client.GetAsync($"api/certifications/{Id}")) 
            {
                if (message.IsSuccessStatusCode) 
                {
                    string json = await message.Content.ReadAsStringAsync();
                    CurrentCertification = JsonConvert.DeserializeObject<CertificationModel>(json);
                }
            }
        }
    }
}















































//Copyrite https://github.com/POLLESSI