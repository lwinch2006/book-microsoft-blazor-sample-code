using Microsoft.AspNetCore.Components;

namespace WasmHosted.Client.Components;

public partial class TimerComponent : ComponentBase
{
    [Parameter]
    public double TimeInSeconds { get; set; }
    
    [Parameter]
    public EventCallback Tick { get; set; }

    protected override void OnInitialized()
    {
        new Timer(
            callback: (_) => Tick.InvokeAsync(),
            state: null,
            dueTime: TimeSpan.FromSeconds(TimeInSeconds),
            period: Timeout.InfiniteTimeSpan);
    }
}