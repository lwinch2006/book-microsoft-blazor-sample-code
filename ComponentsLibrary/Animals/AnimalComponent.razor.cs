using Microsoft.AspNetCore.Components;

namespace ComponentsLibrary.Animals;

public partial class AnimalComponent : ComponentBase
{
    [Parameter]
    public EventCallback ValidSubmit { get; set; }
}

