using Microsoft.AspNetCore.Components;
using WasmHosted.Shared.ViewModels.Animals;

namespace ComponentsLibrary.Animals;

public partial class CatComponent
{
    [Parameter]
    public CatVm? Instance { get; set; }
}