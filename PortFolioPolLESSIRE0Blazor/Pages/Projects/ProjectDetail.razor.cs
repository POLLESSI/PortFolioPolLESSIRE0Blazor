using PortFolioPolLESSIRE0Blazor.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace PortFolioPolLESSIRE0Blazor.Pages.Projects
{
    public partial class ProjectDetail
    {
    #nullable disable
        [Inject]
        public HttpClient? Client { get; set; }
        public ProjectModel? CurrentProject { get; set; }

        [Parameter]
        public int Id { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            await GetProjects();
        }
        private async Task GetProjects()
        {
            if (Id <= 0) return;
            using (HttpResponseMessage message = await Client.GetAsync($"api/projects/{Id}"))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    CurrentProject = JsonConvert.DeserializeObject<ProjectModel>(json);
                }
            }
        }
    }
}

































//Copyrite https://github.com/POLLESSI
