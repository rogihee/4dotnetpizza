using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PizzaApp;
using PizzaComponents.Services;
using PizzaShared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
ConfigureLogging(builder);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// inject our pizza api service
builder.Services.AddScoped<IPizzaApiService, PizzaApiService>();
builder.Services.AddSingleton<IPizzaClient, PizzaClient>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();


static void ConfigureLogging(WebAssemblyHostBuilder builder, string section = "Logging")
{
    builder.Logging.AddConfiguration(builder.Configuration.GetSection(section));
}