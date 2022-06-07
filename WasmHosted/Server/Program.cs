using Microsoft.OpenApi.Models;
using WasmHosted.Server.Extensions;
using WasmHosted.Server.Extensions.FetchData;
using WasmHosted.Server.Extensions.Whiteboard;
using WasmHosted.Server.Services.FetchData;
using WasmHosted.Server.Services.Whiteboard;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddAuthenticationServices()
	.AddAuthorizationServices()
	.AddApplicationServices()
	.AddWhiteboardServices()
	.AddFetchDataWithgRPCServices()
	.AddCors(options =>
	{
		options.AddDefaultPolicy(policy =>
		{
			policy.WithHeaders("Authorization");
			policy.WithOrigins("https://localhost:5001");
		});
	})
	.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blazor Hosted App API", Version = "v1" }); });

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
	.UseSwagger()
	.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"))
	.UseBlazorFrameworkFiles()
	.UseStaticFiles()
	.UseRouting()
	.UseCors()
	.UseAuthentication()
	.UseAuthorization()
	.UseResponseCompression()
	.UseGrpcWeb();

app.MapRazorPages();
app.MapControllers();
app.MapHub<WhiteboardHub>("/whiteboard");
app.MapGrpcService<FetchDataWithgRPCServerService>().EnableGrpcWeb();
app.MapFallbackToFile("index.html");

app.Run();