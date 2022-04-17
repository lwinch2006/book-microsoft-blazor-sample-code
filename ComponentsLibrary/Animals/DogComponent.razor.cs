using Microsoft.AspNetCore.Components;
using WasmHosted.Shared.ViewModels.Animals;

namespace ComponentsLibrary.Animals;

public partial class DogComponent
{
    [Parameter]
    public DogVm? Instance { get; set; }
}