using PortFolioPolLESSIRE0Blazor.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace PortFolioPolLESSIRE0Blazor.Pages.Skills
{
    public partial class SkillDetail
    {
    #nullable disable
        [Inject]
        public HttpClient? Client { get; set; }
        public SkillModel? CurrentSkill { get; set; }

        [Parameter]
        public int Id { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            await GetSkills();
        }
        private async Task GetSkills()
        {
            if (Id <= 0) return;
            using (HttpResponseMessage message = await Client.GetAsync($"api/skills/{Id}"))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    CurrentSkill = JsonConvert.DeserializeObject<SkillModel>(json);
                }
            }
        }
    }
}
































//Copyrite https://github.com/POLLESSI