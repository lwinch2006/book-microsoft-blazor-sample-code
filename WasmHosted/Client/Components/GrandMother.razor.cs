using Microsoft.AspNetCore.Components;

namespace WasmHosted.Client.Components;

public partial class GrandMother
{
    private CounterData? Data { get; set; } = new() { Count = 10 };

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    protected override void OnInitialized()
    {
        Data.CountChanged += (_) => StateHasChanged();
    }
}