using Microsoft.AspNetCore.Components;

namespace WasmHosted.Client.Components;

public partial class LifecycleComponent
{
    private bool _firstParametersSet = true;
    private bool _shouldRender = true;
    private int _counter;

    [Parameter]
    public int Counter
    {
        get => _counter;
        set
        {
            _counter = value;
            Console.WriteLine("Counter set to {0}", _counter);
        }
    }
    
    public LifecycleComponent()
    {
        Console.WriteLine("Inside constructor");
    }

    // public override Task SetParametersAsync(ParameterView parameters)
    // {
    //     Console.WriteLine("SetParametersAsync called");
    //
    //     if (parameters.TryGetValue(nameof(Counter), out int counter))
    //     {
    //         if (counter % 2 == 0)
    //         {
    //             return base.SetParametersAsync(parameters);
    //         }
    //
    //         if (_firstParametersSet)
    //         {
    //             _firstParametersSet = false;
    //             StateHasChanged();
    //         }
    //     }
    //     
    //     return Task.CompletedTask;
    // }
    
    public override Task SetParametersAsync(ParameterView parameters)
    {
        Console.WriteLine("SetParametersAsync called");

        if (parameters.TryGetValue(nameof(Counter), out int counter))
        {
            _shouldRender = counter % 2 == 0;
            return base.SetParametersAsync(parameters);
        }
        
        return Task.CompletedTask;
    }

    protected override void OnParametersSet()
    {
        Console.WriteLine("OnParametersSet called");
        base.OnParametersSet();
    }

    protected override void OnInitialized()
    {
        Console.WriteLine("OnInitialized called");
        base.OnInitialized();
    }

    protected override void OnAfterRender(bool firstRender)
    {
        Console.WriteLine("OnAfterRender called with firstRender {0}", firstRender);
        base.OnAfterRender(firstRender);
    }

    protected override bool ShouldRender()
    {
        Console.WriteLine("ShouldRender called");
        return _shouldRender;
        //return base.ShouldRender();
    }

    public void Dispose()
    {
        Console.WriteLine("Dispose called");
    }
}