using WasmHosted.Server.Extensions;
using WasmHosted.Server.Extensions.Whiteboard;
using WasmHosted.Server.Services.Whiteboard;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices()
    .AddWhiteboardServices();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app
    .UseHttpsRedirection()
    .UseBlazorFrameworkFiles()
    .UseStaticFiles()
    .UseRouting()
    .UseResponseCompression();

app.MapRazorPages();
app.MapControllers();
app.MapHub<WhiteboardHub>("/whiteboard");
app.MapFallbackToFile("index.html");

app.Run();
