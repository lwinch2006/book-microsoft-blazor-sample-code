using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Wasm.Extensions;

await WebAssemblyHostBuilder
	.CreateDefault(args)
	.ConfigureBuilder()
	.CreateApp()
	.RunAsync();