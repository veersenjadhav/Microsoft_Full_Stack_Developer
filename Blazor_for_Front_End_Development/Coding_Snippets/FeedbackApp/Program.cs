using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FeedbackApp.Service;
using FeedbackApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<FeedbackService>();
builder.RootComponents.Add<App>("#app");

await builder.Build().RunAsync();
