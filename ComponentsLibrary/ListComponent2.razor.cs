using Microsoft.AspNetCore.Components;

namespace ComponentsLibrary;

public partial class ListComponent2<TItem>
{
    [Parameter]
    public IReadOnlyList<TItem> Items { get; set; } = Array.Empty<TItem>();

    [Parameter]
    public RenderFragment<RenderFragment>? ListTemplate { get; set; }
    
    [Parameter]
    public RenderFragment<TItem>? ItemTemplate { get; set; }

    private RenderFragment _testRf = (test) =>
    {

    };
}