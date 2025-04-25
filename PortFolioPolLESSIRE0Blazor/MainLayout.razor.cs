using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace PortFolioPolLESSIRE0Blazor
{
    public partial class MainLayout
    {
#nullable disable
        [Inject]
        private IJSRuntime JSRuntime { get; set; }
        private string GetBackgroundImage()
        {
            var hour = DateTime.Now.Hour;

            if (hour < 8) return "/images/dawn.jpg";
            if (hour < 17) return "/images/day.jpg";
            if (hour < 20) return "/images/sunset.jpg";
            return "/images/night.jpg";
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                try
                {
                    //Debug
                    await Task.Delay(100);
                    await JSRuntime.InvokeVoidAsync("initParallax");
                }
                catch (JSException jsEx)
                {
                    Console.WriteLine($"Error JSInterop : {jsEx.Message}");
                }
            }
        }

    }
}
