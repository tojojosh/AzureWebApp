using Microsoft.Azure.Cosmos.Samples.Web.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.Configure<Credentials>(
    builder.Configuration.GetSection(nameof(Credentials))
);

var app = builder.Build();

app.UseRouting();

app.MapRazorPages();

app.UseStaticFiles();

app.Run();