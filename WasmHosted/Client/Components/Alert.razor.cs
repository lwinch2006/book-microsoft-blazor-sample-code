using Microsoft.AspNetCore.Components;

namespace WasmHosted.Client.Components;

public partial class Alert
{
    private bool _show;

    [Parameter]
    public bool Show
    {
        get => _show;
        set
        {
            if (value != _show)
            {
                _show = value;
                ShowChanged.InvokeAsync(_show);
            }
        }
    }

    [Parameter] 
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public EventCallback<bool> ShowChanged { get; set; }

    public void DismissAlert()
    {
        Show = false;
    }
}