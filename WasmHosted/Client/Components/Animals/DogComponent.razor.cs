using Microsoft.AspNetCore.Components;
using WasmHosted.Shared.ViewModels;
using WasmHosted.Shared.ViewModels.Animals;

namespace WasmHosted.Client.Components.Animals;

public partial class DogComponent
{
    [Parameter]
    public DogVm? Instance { get; set; }
}