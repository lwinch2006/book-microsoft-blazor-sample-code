using Microsoft.AspNetCore.Components;

namespace ComponentsLibrary;

public partial class TableComponent<TItem>
{
    [Parameter] 
    public IReadOnlyList<TItem> Items { get; set; } = Array.Empty<TItem>();
    
    [Parameter]
    public RenderFragment? Header { get; set; }
    
    [Parameter]
    public RenderFragment<TItem>? Row { get; set; }
    
    [Parameter]
    public RenderFragment? Footer { get; set; }
}