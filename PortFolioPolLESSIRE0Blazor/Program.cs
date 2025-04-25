using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PortFolioPolLESSIRE0Blazor.Services;
using PortFolioPolLESSIRE0Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient 
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});
builder.Services.AddScoped<CertificationService>();
builder.Services.AddScoped<ContactService>();
builder.Services.AddScoped<EducationService>();
builder.Services.AddScoped<ExperienceService>();
builder.Services.AddScoped<InterestService>();
builder.Services.AddScoped<LanguageService>();
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<SkillService>();

await builder.Build().RunAsync();






















































//Copyrite https://github.com/POLLESSI