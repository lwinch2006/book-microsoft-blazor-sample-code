using Microsoft.AspNetCore.Components;

namespace ComponentsLibrary;

public partial class TwoWayCounter
{
    private int _currentCount;
    private int _increment;

    [Parameter]
    public int CurrentCount
    {
        get => _currentCount;
        set
        {
            if (_currentCount != value)
            {
                _currentCount = value;
                CurrentCountChanged.InvokeAsync(_currentCount);
            }
        }
    }

    [Parameter]
    public int Increment
    {
        get => _increment;
        set
        {
            if (_increment != value)
            {
                _increment = value;
                IncrementChanged.InvokeAsync(_increment);
            }
        }
    }

    [Parameter]
    public EventCallback<int> CurrentCountChanged { get; set; }
    
    [Parameter]
    public EventCallback<int> IncrementChanged { get; set; }

    private void IncrementCount()
    {
        CurrentCount += Increment;
    }
}