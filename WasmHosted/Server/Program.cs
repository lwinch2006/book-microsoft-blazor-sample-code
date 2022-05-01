using WasmHosted.Server.Extensions;
using WasmHosted.Server.Extensions.FetchData;
using WasmHosted.Server.Extensions.Whiteboard;
using WasmHosted.Server.Services.FetchData;
using WasmHosted.Server.Services.Whiteboard;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices()
    .AddWhiteboardServices()
    .AddFetchDataWithgRPCServices();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app
        .UseDeveloperExceptionPage()
        .UseWebAssemblyDebugging();
}
else
{
    app
        .UseExceptionHandler("/Error")
        .UseHsts();
}

app
    .UseHttpsRedirection()
    .UseBlazorFrameworkFiles()
    .UseStaticFiles()
    .UseRouting()
    .UseResponseCompression()
    .UseGrpcWeb();

app.MapRazorPages();
app.MapControllers();
app.MapHub<WhiteboardHub>("/whiteboard");
app.MapGrpcService<FetchDataWithgRPCServerService>().EnableGrpcWeb();
app.MapFallbackToFile("index.html");

app.Run();
