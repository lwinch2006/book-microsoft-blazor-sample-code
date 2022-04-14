using Microsoft.AspNetCore.Components;

namespace WasmHosted.Client.Components.Animals;

public partial class AnimalComponent : ComponentBase
{
    [Parameter]
    public EventCallback ValidSubmit { get; set; }
}

