using Microsoft.AspNetCore.Components;

namespace WasmHosted.Client.Components;

public partial class GrandChild
{
    [CascadingParameter(Name = "gm")]
    public CounterData? Data { get; set; }

    private void Increment()
    {
        Data!.Count++;
    }
}