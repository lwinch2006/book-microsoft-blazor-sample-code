using Microsoft.AspNetCore.Components;

namespace WasmHosted.Client.Components;

public partial class ListComponent<TItem>
{
    [Parameter]
    public IReadOnlyList<TItem> Items { get; set; } = Array.Empty<TItem>();

    [Parameter]
    public RenderFragment<TItem>? ItemTemplate { get; set; }
}